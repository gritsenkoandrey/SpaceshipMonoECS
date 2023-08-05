using System;
using System.Collections.Generic;
using MonoEcs.Core.Components;

namespace MonoEcs.Core.Systems
{
    public abstract class RunSystem : IRunSystem
    {
        private readonly EcsWorld _ecsWorld;
        private readonly List<IComponent> _components;

        protected RunSystem(EcsWorld ecsWorld)
        {
            _ecsWorld = ecsWorld;
            _components = new List<IComponent>();
        }

        protected EntityComponent<T> Get<T>() where T : struct
        {
            Type type = typeof(T);
            
            for (int i = 0; i < _ecsWorld.Components.Count; i++)
            {
                if (_ecsWorld.Components[i].Type == type)
                {
                    _components.Add(_ecsWorld.Components[i]);

                    return (EntityComponent<T>) _ecsWorld.Components[i];
                }
            }

            throw new InvalidOperationException($"Component of type {typeof(T)} not found.");
        }

        protected bool Filter(int entity)
        {
            int count = 0;
            
            for (int i = 0; i < _components.Count; i++)
            {
                if (!_components[i].HasComponent(entity))
                {
                    return false;
                }
            }

            for (int i = 0; i < _ecsWorld.Components.Count; i++)
            {
                if (_ecsWorld.Components[i].HasComponent(entity))
                {
                    count++;
                }
            }
            
            return count == _components.Count;
        }
    }
}
using System;
using System.Collections.Generic;
using Core.Components;

namespace Core.Services
{
    public sealed class ComponentRegistryService
    {
        private readonly List<IComponent> _components;
        public IReadOnlyList<IComponent> Components => _components;

        public ComponentRegistryService()
        {
            _components = new List<IComponent>();
        }

        public void RegisterComponent<T>() where T : struct
        {
            _components.Add(new EntityComponent<T>(16));
        }

        public ref T GetComponent<T>(int entity) where T : struct
        {
            Type type = typeof(T);
            
            for (int i = 0; i < _components.Count; i++)
            {
                if (_components[i].GetTypeComponent() == type)
                {
                    return ref ((EntityComponent<T>) _components[i]).GetComponent(entity);
                }
            }
            
            throw new InvalidOperationException($"Component of type {typeof(T)} not found");
        }

        public void SetComponent<T>(int entity, ref T component) where T : struct
        {
            Type type = typeof(T);

            for (int i = 0; i < _components.Count; i++)
            {
                if (_components[i].GetTypeComponent() == type)
                {
                    ((EntityComponent<T>)_components[i]).SetComponent(entity, ref component);
                }
            }
        }
    }
}
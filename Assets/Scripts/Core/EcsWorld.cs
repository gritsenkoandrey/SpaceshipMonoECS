using System;
using System.Collections.Generic;
using MonoEcs.Core.Components;
using MonoEcs.Core.Systems;

namespace MonoEcs.Core
{
    public sealed class EcsWorld
    {
        private readonly List<IComponent> _components;
        private readonly List<IUpdateSystem> _updateSystems;
        private readonly List<ILateUpdateSystem> _lateUpdateSystems;
        private readonly List<IFixedUpdateSystem> _fixedUpdateSystems;
        private readonly List<IInitializeSystem> _initializesSystems;
        private readonly List<bool> _entities;

        public IReadOnlyList<IComponent> Components => _components;

        public EcsWorld()
        {
            _components = new List<IComponent>();
            _updateSystems = new List<IUpdateSystem>();
            _lateUpdateSystems = new List<ILateUpdateSystem>();
            _fixedUpdateSystems = new List<IFixedUpdateSystem>();
            _initializesSystems = new List<IInitializeSystem>();
            _entities = new List<bool>();
        }

        public int RegisterEntity()
        {
            int id = 0;
            int count = _entities.Count;

            for (; id < count; id++)
            {
                if (!_entities[id])
                {
                    _entities[id] = true;
                    
                    return id;
                }
            }

            id = count;
            
            _entities.Add(true);

            for (int i = 0; i < _components.Count; i++)
            {
                _components[i].AddComponent();
            }

            return id;
        }

        public void UnregisterEntity(int index)
        {
            _entities[index] = false;
            
            for (int i = 0; i < _components.Count; i++)
            {
                _components[i].RemoveComponent(index);
            }
        }
        
        public ref T GetComponent<T>(int entity) where T : struct
        {
            Type type = typeof(T);
            
            for (int i = 0; i < _components.Count; i++)
            {
                if (_components[i].Type == type)
                {
                    return ref ((EntityComponent<T>) _components[i]).GetComponent(entity);
                }
            }
            
            throw new InvalidOperationException($"Component of type {typeof(T)} not found.");
        }

        public void SetComponent<T>(int entity, ref T component) where T : struct
        {
            Type type = typeof(T);

            for (int i = 0; i < _components.Count; i++)
            {
                if (_components[i].Type == type)
                {
                    ((EntityComponent<T>)_components[i]).SetComponent(entity, ref component);
                }
            }
        }
        
        public void Update()
        {
            for (int i = 0; i < _updateSystems.Count; i++)
            {
                for (int entity = 0; entity < _entities.Count; entity++)
                {
                    if (_entities[entity])
                    {
                        _updateSystems[i].Update(entity);
                    }
                }
            }
        }
        
        public void FixedUpdate()
        {
            for (int i = 0; i < _fixedUpdateSystems.Count; i++)
            {
                for (int entity = 0; entity < _entities.Count; entity++)
                {
                    if (_entities[entity])
                    {
                        _fixedUpdateSystems[i].FixedUpdate(entity);
                    }
                }
            }
        }
        
        public void LateUpdate()
        {
            for (int i = 0; i < _lateUpdateSystems.Count; i++)
            {
                for (int entity = 0; entity < _entities.Count; entity++)
                {
                    if (_entities[entity])
                    {
                        _lateUpdateSystems[i].LateUpdate(entity);
                    }
                }
            }
        }

        public void EnableSystem()
        {
            for (int i = 0; i < _initializesSystems.Count; i++)
            {
                _initializesSystems[i].OnEnableSystem();
            }
        }
        
        public void DisableSystem()
        {
            for (int i = 0; i < _initializesSystems.Count; i++)
            {
                _initializesSystems[i].OnDisableSystem();
            }
        }
        
        public void BindComponent<T>() where T : struct
        {
            _components.Add(new EntityComponent<T>(16));
        }

        public void BindSystem<T>(T system) where T : ISystem
        {
            switch (system)
            {
                case IUpdateSystem updateSystem:
                    _updateSystems.Add(updateSystem);
                    break;
                case IFixedUpdateSystem fixedUpdateSystem:
                    _fixedUpdateSystems.Add(fixedUpdateSystem);
                    break;
                case ILateUpdateSystem lateUpdateSystem:
                    _lateUpdateSystems.Add(lateUpdateSystem);
                    break;
                case IInitializeSystem initializeSystem:
                    _initializesSystems.Add(initializeSystem);
                    break;
            }
        }
    }
}
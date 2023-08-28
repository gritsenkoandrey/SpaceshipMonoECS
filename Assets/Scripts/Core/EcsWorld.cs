using System;
using System.Collections.Generic;
using AirPlane.Core.Components;
using AirPlane.Core.Systems;

namespace AirPlane.Core
{
    public sealed class EcsWorld
    {
        private readonly List<bool> _entities;
        private readonly List<IComponent> _components;
        private readonly List<IInitializeSystem> _initializeSystems;
        private readonly List<IUpdateSystem> _updateSystems;
        private readonly List<IFixedUpdateSystem> _fixedUpdateSystems;
        private readonly List<ILateUpdateSystem> _lateUpdateSystems;

        public IReadOnlyList<IComponent> Components => _components;

        public EcsWorld()
        {
            _entities = new List<bool>();
            _components = new List<IComponent>();
            _initializeSystems = new List<IInitializeSystem>();
            _updateSystems = new List<IUpdateSystem>();
            _fixedUpdateSystems = new List<IFixedUpdateSystem>();
            _lateUpdateSystems = new List<ILateUpdateSystem>();
        }

        public int RegisterEntity()
        {
            int id;
            int count = _entities.Count;

            for (id = 0; id < count; id++)
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
                if (_components[i].GetTypeComponent() == type)
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
                if (_components[i].GetTypeComponent() == type)
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
            for (int i = 0; i < _initializeSystems.Count; i++)
            {
                _initializeSystems[i].OnEnableSystem();
            }
        }
        
        public void DisableSystem()
        {
            for (int i = 0; i < _initializeSystems.Count; i++)
            {
                _initializeSystems[i].OnDisableSystem();
            }
        }
        
        public void RegisterComponent<T>() where T : struct
        {
            _components.Add(new EntityComponent<T>(16));
        }

        public void RegisterSystem<T>(T system) where T : ISystem
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
                    _initializeSystems.Add(initializeSystem);
                    break;
            }
        }
    }
}
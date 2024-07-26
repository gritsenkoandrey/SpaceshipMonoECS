using System.Collections.Generic;
using Core.Systems;

namespace Core.Services
{
    public sealed class SystemRegistryService
    {
        private readonly IList<IInitializeSystem> _initializeSystems;
        private readonly IList<IUpdateSystem> _updateSystems;
        private readonly IList<IFixedUpdateSystem> _fixedUpdateSystems;
        private readonly IList<ILateUpdateSystem> _lateUpdateSystems;

        public SystemRegistryService()
        {
            _initializeSystems = new List<IInitializeSystem>();
            _updateSystems = new List<IUpdateSystem>();
            _fixedUpdateSystems = new List<IFixedUpdateSystem>();
            _lateUpdateSystems = new List<ILateUpdateSystem>();
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

        public void Update(IReadOnlyList<bool> entities)
        {
            for (int i = 0; i < _updateSystems.Count; i++)
            {
                for (int entity = 0; entity < entities.Count; entity++)
                {
                    if (entities[entity])
                    {
                        _updateSystems[i].Update(entity);
                    }
                }
            }
        }

        public void FixedUpdate(IReadOnlyList<bool> entities)
        {
            for (int i = 0; i < _fixedUpdateSystems.Count; i++)
            {
                for (int entity = 0; entity < entities.Count; entity++)
                {
                    if (entities[entity])
                    {
                        _fixedUpdateSystems[i].FixedUpdate(entity);
                    }
                }
            }
        }

        public void LateUpdate(IReadOnlyList<bool> entities)
        {
            for (int i = 0; i < _lateUpdateSystems.Count; i++)
            {
                for (int entity = 0; entity < entities.Count; entity++)
                {
                    if (entities[entity])
                    {
                        _lateUpdateSystems[i].LateUpdate(entity);
                    }
                }
            }
        }
    }
}
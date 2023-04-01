using System;
using AndreyGritsenko.MonoECS.Core;
using AndreyGritsenko.MonoECS.Dependency.Input;
using AndreyGritsenko.MonoECS.Dependency.Loader;
using AndreyGritsenko.MonoECS.Dependency.StateMachine;
using AndreyGritsenko.MonoECS.Example;
using VContainer;
using VContainer.Unity;

namespace AndreyGritsenko.MonoECS.Scope
{
    public sealed class BootstrapEntryPoint : IInitializable, IStartable, ITickable, IFixedTickable, ILateTickable, IDisposable
    {
        private SystemBase[] _systems;

        private readonly IInputService _inputService;
        private readonly ISceneLoader _sceneLoader;
        private readonly IGameStateMachine _gameStateMachine;
        
        public BootstrapEntryPoint(IObjectResolver container)
        {
            _inputService = container.Resolve<IInputService>();
            _sceneLoader = container.Resolve<ISceneLoader>();
            _gameStateMachine = container.Resolve<IGameStateMachine>();
        }
        
        void IInitializable.Initialize() => CreateSystems();
        void IStartable.Start()
        {
            EnableSystems();
            
            _gameStateMachine.Enter<StateBootstrap>();
        }
        void ITickable.Tick() => UpdateSystems();
        void IFixedTickable.FixedTick() => FixedUpdateSystems();
        void ILateTickable.LateTick() => LateUpdateSystems();
        void IDisposable.Dispose() => DisableSystem();

        private void CreateSystems()
        {
            _systems = new SystemBase[]
            {
                new ExampleSystem(_inputService),
            };
        }

        private void EnableSystems()
        {
            for (int i = 0; i < _systems.Length; i++)
            {
                _systems[i].EnableSystem();
            }
        }

        private void UpdateSystems()
        {
            for (int i = 0; i < _systems.Length; i++)
            {
                _systems[i].UpdateSystem();
            }
        }

        private void FixedUpdateSystems()
        {
            for (int i = 0; i < _systems.Length; i++)
            {
                _systems[i].FixedUpdateSystem();
            }
        }

        private void LateUpdateSystems()
        {
            for (int i = 0; i < _systems.Length; i++)
            {
                _systems[i].LateUpdateSystem();
            }
        }

        private void DisableSystem()
        {
            for (int i = 0; i < _systems.Length; i++)
            {
                _systems[i].DisableSystem();
            }
            
            Clear();
        }

        private void Clear() => _systems = Array.Empty<SystemBase>();
    }
}
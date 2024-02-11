using Dependency.Input;
using Dependency.Loader;
using Dependency.StateMachine;
using JetBrains.Annotations;
using VContainer;
using VContainer.Unity;

namespace Scope
{
    [UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
    public sealed class BootstrapEntryPoint : IStartable, ITickable
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly IJoystickService _joystickService;
        private readonly IGameStateMachine _gameStateMachine;

        public BootstrapEntryPoint(IObjectResolver container)
        {
            _sceneLoader = container.Resolve<ISceneLoader>();
            _joystickService = container.Resolve<IJoystickService>();
            _gameStateMachine = container.Resolve<IGameStateMachine>();
        }
        
        void IStartable.Start() => _gameStateMachine.Enter<StateBootstrap>();
        
        void ITickable.Tick() => _joystickService.Execute();
    }
}
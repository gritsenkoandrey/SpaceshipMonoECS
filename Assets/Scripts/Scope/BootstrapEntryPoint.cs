using AirPlane.Dependency.Input;
using AirPlane.Dependency.Loader;
using AirPlane.Dependency.StateMachine;
using VContainer;
using VContainer.Unity;

namespace AirPlane.Scope
{
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
using App;
using Dependency.Input;
using Dependency.Loader;
using VContainer;

namespace Dependency.StateMachine
{
    public sealed class StateBootstrap : IEnterState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly IJoystickService _joystickService;

        public StateBootstrap(IGameStateMachine gameStateMachine, IObjectResolver container)
        {
            _gameStateMachine = gameStateMachine;
            
            _sceneLoader = container.Resolve<ISceneLoader>();
            _joystickService = container.Resolve<IJoystickService>();
        }

        void IEnterState.Enter()
        {
            _joystickService.Init();
            
            _sceneLoader.Load(SceneName.Bootstrap, Next);
        }

        void IExitState.Exit() { }
        private void Next() => _gameStateMachine.Enter<StateLoadLevel, string>(SceneName.Game);
    }
}
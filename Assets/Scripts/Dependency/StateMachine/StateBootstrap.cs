using AndreyGritsenko.MonoECS.Dependency.Loader;
using VContainer;

namespace AndreyGritsenko.MonoECS.Dependency.StateMachine
{
    public sealed class StateBootstrap : IEnterState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly ISceneLoader _sceneLoader;
        
        private const string Bootstrap = "Bootstrap";
        private const string Game = "Game";

        public StateBootstrap(IGameStateMachine gameStateMachine, IObjectResolver container)
        {
            _gameStateMachine = gameStateMachine;
            
            _sceneLoader = container.Resolve<ISceneLoader>();
        }

        public void Enter() => _sceneLoader.Load(Bootstrap, Next);
        public void Exit() { }
        private void Next() => _gameStateMachine.Enter<StateLoadLevel, string>(Game);
    }
}
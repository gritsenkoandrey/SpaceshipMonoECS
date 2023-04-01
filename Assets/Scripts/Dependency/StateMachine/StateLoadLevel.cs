using AndreyGritsenko.MonoECS.Dependency.Loader;
using VContainer;

namespace AndreyGritsenko.MonoECS.Dependency.StateMachine
{
    public sealed class StateLoadLevel : IEnterLoadState<string>
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly ISceneLoader _sceneLoader;

        public StateLoadLevel(IGameStateMachine gameStateMachine, IObjectResolver container)
        {
            _gameStateMachine = gameStateMachine;
            
            _sceneLoader = container.Resolve<ISceneLoader>();
        }

        public void Enter(string scene) => _sceneLoader.Load(scene, Next);
        public void Exit() { }
        private void Next() => _gameStateMachine.Enter<StateGameLoop>();
    }
}
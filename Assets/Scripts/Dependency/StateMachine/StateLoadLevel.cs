using AirPlane.Dependency.Loader;
using VContainer;

namespace AirPlane.Dependency.StateMachine
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

        void IEnterLoadState<string>.Enter(string scene) => _sceneLoader.Load(scene, Next);
        void IExitState.Exit() { }
        private void Next() => _gameStateMachine.Enter<StateGameLoop>();
    }
}
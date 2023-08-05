using VContainer;

namespace MonoEcs.Dependency.StateMachine
{
    public sealed class StateGameLoop : IEnterState
    {
        private readonly IGameStateMachine _gameStateMachine;

        public StateGameLoop(IGameStateMachine gameStateMachine, IObjectResolver container)
        {
            _gameStateMachine = gameStateMachine;
        }

        void IEnterState.Enter() { }
        void IExitState.Exit() { }
    }
}
using VContainer;

namespace AndreyGritsenko.MonoECS.Dependency.StateMachine
{
    public sealed class StateGameLoop : IEnterState
    {
        private readonly IGameStateMachine _gameStateMachine;

        public StateGameLoop(IGameStateMachine gameStateMachine, IObjectResolver container)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void Enter() { }
        public void Exit() { }
    }
}
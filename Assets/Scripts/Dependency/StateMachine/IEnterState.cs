namespace Dependency.StateMachine
{
    public interface IEnterState : IExitState
    {
        public void Enter();
    }
}
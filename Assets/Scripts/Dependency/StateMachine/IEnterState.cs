namespace AndreyGritsenko.MonoECS.Dependency.StateMachine
{
    public interface IEnterState : IExitState
    {
        public void Enter();
    }
}
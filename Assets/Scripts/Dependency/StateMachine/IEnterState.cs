namespace AirPlane.Dependency.StateMachine
{
    public interface IEnterState : IExitState
    {
        public void Enter();
    }
}
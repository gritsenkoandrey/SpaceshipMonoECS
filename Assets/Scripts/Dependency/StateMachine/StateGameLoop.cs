using Dependency.Input;
using VContainer;

namespace Dependency.StateMachine
{
    public sealed class StateGameLoop : IEnterState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IJoystickService _joystickService;

        public StateGameLoop(IGameStateMachine gameStateMachine, IObjectResolver container)
        {
            _gameStateMachine = gameStateMachine;

            _joystickService = container.Resolve<IJoystickService>();
        }

        void IEnterState.Enter()
        {
            _joystickService.Enable(true);
        }

        void IExitState.Exit()
        {
            _joystickService.Enable(false);
        }
    }
}
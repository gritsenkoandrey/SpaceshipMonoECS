﻿namespace AndreyGritsenko.MonoECS.Dependency.StateMachine
{
    public interface IEnterLoadState<in TLoad> : IExitState
    {
        public void Enter(TLoad load);
    }
}
namespace AndreyGritsenko.MonoECS.Core
{
    public abstract class System
    {
        public void EnableSystem() => OnEnableSystem();
        public void DisableSystem() => OnDisableSystem();

        protected virtual void OnEnableSystem() { }
        protected virtual void OnDisableSystem() { }
    }
}
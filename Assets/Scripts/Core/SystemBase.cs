namespace AndreyGritsenko.MonoECS.Core
{
    public abstract class SystemBase
    {
        public void EnableSystem() => OnEnableSystem();
        public void DisableSystem() => OnDisableSystem();
        public void UpdateSystem() => OnUpdateSystem();
        public void FixedUpdateSystem() => OnFixedUpdateSystem();
        public void LateUpdateSystem() => OnLateUpdateSystem();

        protected virtual void OnEnableSystem() { }
        protected virtual void OnDisableSystem() { }
        protected virtual void OnUpdateSystem() { }
        protected virtual void OnFixedUpdateSystem() { }
        protected virtual void OnLateUpdateSystem() { }
    }
}
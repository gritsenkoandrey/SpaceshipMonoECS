namespace AndreyGritsenko.MonoECS.Core
{
    public abstract class SystemComponent<T> : System where T : Entity
    {
        protected override void OnEnableSystem()
        {
            base.OnEnableSystem();
            
            EntityContainer<T>.OnRegistered += OnEnableComponent;
            EntityContainer<T>.OnUnregistered += OnDisableComponent;
        }

        protected override void OnDisableSystem()
        {
            base.OnDisableSystem();
            
            EntityContainer<T>.OnRegistered -= OnEnableComponent;
            EntityContainer<T>.OnUnregistered -= OnDisableComponent;
        }

        protected virtual void OnEnableComponent(T component) => Entities.Add(component);
        protected virtual void OnDisableComponent(T component) => Entities.Remove(component);
    }
}
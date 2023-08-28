using Core.Entities;

namespace Core.Systems
{
    public abstract class InitializeSystem<T> : IInitializeSystem where T : EntityBase
    {
        private readonly EcsWorld _ecsWorld;

        protected InitializeSystem(EcsWorld ecsWorld)
        {
            _ecsWorld = ecsWorld;
        }

        protected virtual void Enable(T entity) { }
        protected virtual void Disable(T entity) { }

        public void OnEnableSystem()
        {
            EntityRegister<T>.OnRegistered += OnRegistered;
            EntityRegister<T>.OnUnregistered += OnUnregistered;
        }

        public void OnDisableSystem()
        {
            EntityRegister<T>.OnRegistered -= OnRegistered;
            EntityRegister<T>.OnUnregistered -= OnUnregistered;
        }

        private void OnRegistered(T entity)
        {
            int index = _ecsWorld.RegisterEntity();

            entity.SetId(index);
            
            Enable(entity);
        }

        private void OnUnregistered(T entity)
        {
            _ecsWorld.UnregisterEntity(entity.Id);
            
            Disable(entity);
        }
    }
}
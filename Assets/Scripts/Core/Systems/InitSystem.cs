using MonoEcs.Core.Entities;

namespace MonoEcs.Core.Systems
{
    public abstract class InitSystem<T> : IInitializeSystem where T : EntityBase
    {
        private readonly EcsWorld _ecsWorld;

        protected InitSystem(EcsWorld ecsWorld)
        {
            _ecsWorld = ecsWorld;
        }

        protected virtual void Init(T entity) { }

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
            
            Init(entity);
        }

        private void OnUnregistered(T entity)
        {
            _ecsWorld.UnregisterEntity(entity.Id);
        }
    }
}
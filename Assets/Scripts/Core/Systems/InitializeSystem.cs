using Core.Entities;
using Core.Services;

namespace Core.Systems
{
    public abstract class InitializeSystem<T> : IInitializeSystem where T : EntityBase
    {
        protected readonly EntitiesRegistryService EntitiesRegistryService;
        protected readonly ComponentRegistryService ComponentRegistryService;
        protected readonly SystemRegistryService SystemRegistryService;

        protected InitializeSystem(EcsWorld ecsWorld)
        {
            EntitiesRegistryService = ecsWorld.EntitiesRegistryService;
            ComponentRegistryService = ecsWorld.ComponentRegistryService;
            SystemRegistryService = ecsWorld.SystemRegistryService;
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
            int index = EntitiesRegistryService.RegisterEntity();
            
            ComponentRegistryService.AddComponent();

            entity.SetId(index);
            
            Enable(entity);
        }

        private void OnUnregistered(T entity)
        {
            EntitiesRegistryService.UnregisterEntity(entity.Id);
            ComponentRegistryService.RemoveComponent(entity.Id);
            
            Disable(entity);
        }
    }
}
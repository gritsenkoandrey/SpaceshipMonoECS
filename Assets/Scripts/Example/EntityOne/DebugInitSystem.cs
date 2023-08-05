using MonoEcs.Core;
using MonoEcs.Core.Systems;
using MonoEcs.Example.Components;
using UnityEngine;

namespace MonoEcs.Example.EntityOne
{
    public sealed class DebugInitSystem : InitializeSystem<DebugEntity>
    {
        private readonly EcsWorld _ecsWorld;

        public DebugInitSystem(EcsWorld ecsWorld) : base(ecsWorld)
        {
            _ecsWorld = ecsWorld;
        }

        protected override void Enable(DebugEntity entity)
        {
            base.Enable(entity);
            
            ref DebugOneComponent debugOneComponent = ref _ecsWorld.GetComponent<DebugOneComponent>(entity.Id);
            ref DebugTwoComponent debugTwoComponent = ref _ecsWorld.GetComponent<DebugTwoComponent>(entity.Id);

            _ecsWorld.SetComponent(entity.Id, ref debugOneComponent);
            _ecsWorld.SetComponent(entity.Id, ref debugTwoComponent);
            
            debugOneComponent.Value = entity.Vector;
            debugTwoComponent.Value = entity.Index;
        }

        protected override void Disable(DebugEntity entity)
        {
            base.Disable(entity);
            
            Debug.Log($"Disable {entity.Id}");
        }
    }
}
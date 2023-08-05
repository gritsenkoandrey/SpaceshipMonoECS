using MonoEcs.Core;
using MonoEcs.Core.Systems;
using MonoEcs.Example.Components;
using UnityEngine;

namespace MonoEcs.Example.EntityTwo
{
    public class ColorInitSystem : InitializeSystem<ColorEntity>
    {
        private readonly EcsWorld _ecsWorld;

        public ColorInitSystem(EcsWorld ecsWorld) : base(ecsWorld)
        {
            _ecsWorld = ecsWorld;
        }

        protected override void Enable(ColorEntity entity)
        {
            base.Enable(entity);
            
            ref DebugOneComponent debugOneComponent = ref _ecsWorld.GetComponent<DebugOneComponent>(entity.Id);

            _ecsWorld.SetComponent(entity.Id, ref debugOneComponent);

            debugOneComponent.Value = entity.Vector;
        }
        
        protected override void Disable(ColorEntity entity)
        {
            base.Disable(entity);
            
            Debug.Log($"Disable {entity.Id}");
        }
    }
}
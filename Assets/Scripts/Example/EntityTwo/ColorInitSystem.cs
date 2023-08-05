using MonoEcs.Core;
using MonoEcs.Core.Systems;
using MonoEcs.Example.Components;
using UnityEngine;

namespace MonoEcs.Example.EntityTwo
{
    public class ColorInitSystem : InitSystem<ColorEntity>
    {
        private readonly EcsWorld _ecsWorld;

        public ColorInitSystem(EcsWorld ecsWorld) : base(ecsWorld)
        {
            _ecsWorld = ecsWorld;
        }

        protected override void Init(ColorEntity entity)
        {
            base.Init(entity);
            
            ref DebugOneComponent debugOneComponent = ref _ecsWorld.GetComponent<DebugOneComponent>(entity.Id);

            _ecsWorld.SetComponent(entity.Id, ref debugOneComponent);

            debugOneComponent.Value = new Vector3(10f,10f,10f);
        }
    }
}
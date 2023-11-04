using Core;
using Core.Systems;
using Game.Components;
using Game.Entities;
using UnityEngine;

namespace Game.Systems.Init
{
    public sealed class PlanetMoveInitSystem : InitializeSystem<PlanetEntity>
    {
        private readonly EcsWorld _ecsWorld;
        
        public PlanetMoveInitSystem(EcsWorld ecsWorld) : base(ecsWorld)
        {
            _ecsWorld = ecsWorld;
        }

        protected override void Enable(PlanetEntity entity)
        {
            base.Enable(entity);
            
            ref TransformComponent transformComponent = ref _ecsWorld.ComponentRegistryService.GetComponent<TransformComponent>(entity.Id);
            ref PlanetComponent planetComponent = ref _ecsWorld.ComponentRegistryService.GetComponent<PlanetComponent>(entity.Id);
            
            _ecsWorld.ComponentRegistryService.SetComponent(entity.Id, ref transformComponent);
            _ecsWorld.ComponentRegistryService.SetComponent(entity.Id, ref planetComponent);

            transformComponent.Transform = entity.transform;
            
            planetComponent.Center = entity.Center;
            planetComponent.CurrentOrbitAngle = 0f;
            planetComponent.CurrentRotateAngle = 0f;
            planetComponent.Sin = 1f;
            planetComponent.Cos = 1f;
            planetComponent.DistanceToCenter = Vector3.Distance(transformComponent.Transform.position, planetComponent.Center.position);
            planetComponent.Speed = Random.Range(-1f, 1f);
        }

        protected override void Disable(PlanetEntity entity)
        {
            base.Disable(entity);
        }
    }
}
using Core;
using Core.Systems;
using Game.Components;
using UnityEngine;

namespace Game.Systems.Run
{
    public sealed class PlanetMoveRunSystem : RunSystem, IUpdateSystem
    {
        private readonly Filter<TransformComponent, PlanetComponent> _filter;

        public PlanetMoveRunSystem(EcsWorld ecsWorld) : base(ecsWorld)
        {
            _filter = new Filter<TransformComponent, PlanetComponent>(ecsWorld);
        }

        void IUpdateSystem.Update(int entity)
        {
            if (_filter.Contain(entity))
            {
                ref TransformComponent transformComponent = ref _filter.GetT1(entity);
                ref PlanetComponent planetComponent = ref _filter.GetT2(entity);

                Move(ref transformComponent, ref planetComponent);
                Rotate(ref transformComponent, ref planetComponent);
            }
        }

        private void Move(ref TransformComponent transform, ref PlanetComponent planet)
        {
            Vector3 position = planet.Center.position;
                
            position.x += Mathf.Sin(planet.CurrentOrbitAngle) * planet.DistanceToCenter * planet.Sin;
            position.z += Mathf.Cos(planet.CurrentOrbitAngle) * planet.DistanceToCenter * planet.Cos;

            transform.Transform.position = position;

            planet.CurrentOrbitAngle += 0.5f * Time.deltaTime * planet.Speed;
        }

        private void Rotate(ref TransformComponent transform, ref PlanetComponent planet)
        {
            transform.Transform.rotation = Quaternion.AngleAxis(planet.CurrentRotateAngle, Vector3.up * planet.Speed);
            
            planet.CurrentRotateAngle += Time.deltaTime * 100f;
        }
    }
}
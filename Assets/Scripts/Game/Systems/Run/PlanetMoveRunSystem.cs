using AirPlane.Core;
using AirPlane.Core.Components;
using AirPlane.Core.Systems;
using AirPlane.Game.Components;
using UnityEngine;

namespace AirPlane.Game.Systems.Run
{
    public sealed class PlanetMoveRunSystem : RunSystem, IUpdateSystem
    {
        private readonly EntityComponent<TransformComponent> _transformComponent;
        private readonly EntityComponent<PlanetComponent> _planetComponent;
        
        public PlanetMoveRunSystem(EcsWorld ecsWorld) : base(ecsWorld)
        {
            _transformComponent = Get<TransformComponent>();
            _planetComponent = Get<PlanetComponent>();
        }

        public void Update(int entity)
        {
            if (Filter(entity))
            {
                ref TransformComponent transformComponent = ref _transformComponent.GetComponent(entity);
                ref PlanetComponent planetComponent = ref _planetComponent.GetComponent(entity);

                Move(transformComponent, ref planetComponent);
                Rotate(transformComponent, ref planetComponent);
            }
        }

        private void Move(TransformComponent transform, ref PlanetComponent planet)
        {
            Vector3 position = planet.Center.position;
                
            position.x += Mathf.Sin(planet.CurrentOrbitAngle) * planet.DistanceToCenter * planet.Sin;
            position.z += Mathf.Cos(planet.CurrentOrbitAngle) * planet.DistanceToCenter * planet.Cos;

            transform.Transform.position = position;

            planet.CurrentOrbitAngle += 0.5f * Time.deltaTime * planet.Speed;
        }

        private void Rotate(TransformComponent transform, ref PlanetComponent planet)
        {
            transform.Transform.rotation = Quaternion.AngleAxis(planet.CurrentRotateAngle, Vector3.up * planet.Speed);
            
            planet.CurrentRotateAngle += Time.deltaTime * 100f;
        }
    }
}
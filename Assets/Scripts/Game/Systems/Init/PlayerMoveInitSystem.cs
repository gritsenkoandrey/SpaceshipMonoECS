using Core;
using Core.Systems;
using Game.Components;
using Game.Entities;

namespace Game.Systems.Init
{
    public sealed class PlayerMoveInitSystem : InitializeSystem<PlayerEntity>
    {
        private readonly EcsWorld _ecsWorld;
        
        //todo put in config
        private const float MoveSpeed = 50f;
        private const float RotationSpeed = 100f;

        public PlayerMoveInitSystem(EcsWorld ecsWorld) : base(ecsWorld)
        {
            _ecsWorld = ecsWorld;
        }

        protected override void Enable(PlayerEntity entity)
        {
            base.Enable(entity);

            ref TransformComponent transformComponent = ref _ecsWorld.GetComponent<TransformComponent>(entity.Id);
            ref PlayerComponent playerComponent = ref _ecsWorld.GetComponent<PlayerComponent>(entity.Id);
            
            _ecsWorld.SetComponent(entity.Id, ref transformComponent);
            _ecsWorld.SetComponent(entity.Id, ref playerComponent);

            transformComponent.Transform = entity.transform;
            playerComponent.MoveSpeed = MoveSpeed;
            playerComponent.RotationSpeed = RotationSpeed;
        }

        protected override void Disable(PlayerEntity entity)
        {
            base.Disable(entity);
        }
    }
}
using Core;
using Core.Systems;
using Game.Components;
using Game.Entities;

namespace Game.Systems.Init
{
    public sealed class PlayerMoveInitSystem : InitializeSystem<PlayerEntity>
    {
        private readonly Filter<TransformComponent, PlayerComponent, AccelerateComponent, InputComponent, SpeedComponent> _filter;
        public PlayerMoveInitSystem(EcsWorld ecsWorld) : base(ecsWorld)
        {
            _filter = new Filter<TransformComponent, PlayerComponent, AccelerateComponent, InputComponent, SpeedComponent>(ecsWorld);
        }

        protected override void Enable(PlayerEntity entity)
        {
            base.Enable(entity);

            ref TransformComponent transformComponent = ref _filter.SetT1(entity.Id);
            ref PlayerComponent playerComponent = ref _filter.SetT2(entity.Id);
            ref AccelerateComponent accelerateComponent = ref _filter.SetT3(entity.Id);
            ref InputComponent inputComponent = ref _filter.SetT4(entity.Id);
            ref SpeedComponent speedComponent = ref _filter.SetT5(entity.Id);

            transformComponent.Transform = entity.transform;
            
            speedComponent.MoveSpeed = 50f;
            speedComponent.RotationSpeed = 100f;
            
            accelerateComponent.MinFactor = 0.5f;
            accelerateComponent.MaxFactor = 1f;
            accelerateComponent.Factor = 1f;
            accelerateComponent.AngleDetection = 15f;
            accelerateComponent.MaxTime = 2f;
            accelerateComponent.FastMultiplier = 4f;
            accelerateComponent.SlowMultiplier = 1f;
        }

        protected override void Disable(PlayerEntity entity)
        {
            base.Disable(entity);
        }
    }
}
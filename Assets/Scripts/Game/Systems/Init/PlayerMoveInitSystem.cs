﻿using Core;
using Core.Systems;
using Game.Components;
using Game.Entities;

namespace Game.Systems.Init
{
    public sealed class PlayerMoveInitSystem : InitializeSystem<PlayerEntity>
    {
        private readonly EcsWorld _ecsWorld;

        public PlayerMoveInitSystem(EcsWorld ecsWorld) : base(ecsWorld)
        {
            _ecsWorld = ecsWorld;
        }

        protected override void Enable(PlayerEntity entity)
        {
            base.Enable(entity);

            ref TransformComponent transformComponent = ref _ecsWorld.GetComponent<TransformComponent>(entity.Id);
            ref PlayerComponent playerComponent = ref _ecsWorld.GetComponent<PlayerComponent>(entity.Id);
            ref AccelerateComponent accelerateComponent = ref _ecsWorld.GetComponent<AccelerateComponent>(entity.Id);
            ref InputComponent inputComponent = ref _ecsWorld.GetComponent<InputComponent>(entity.Id);
            ref SpeedComponent speedComponent = ref _ecsWorld.GetComponent<SpeedComponent>(entity.Id);

            _ecsWorld.SetComponent(entity.Id, ref transformComponent);
            _ecsWorld.SetComponent(entity.Id, ref playerComponent);
            _ecsWorld.SetComponent(entity.Id, ref accelerateComponent);
            _ecsWorld.SetComponent(entity.Id, ref inputComponent);
            _ecsWorld.SetComponent(entity.Id, ref speedComponent);

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
using Core;
using Core.Components;
using Core.Systems;
using Game.Components;
using UnityEngine;

namespace Game.Systems.Run
{
    public sealed class PlayerAccelerateRunSystem : RunSystem, ILateUpdateSystem
    {
        private readonly EntityComponent<TransformComponent> _transformComponent;
        private readonly EntityComponent<PlayerComponent> _playerComponent;
        private readonly EntityComponent<AccelerateComponent> _accelerateComponent;
        private readonly EntityComponent<InputComponent> _inputComponent;

        public PlayerAccelerateRunSystem(EcsWorld ecsWorld) : base(ecsWorld)
        {
            _transformComponent = Get<TransformComponent>();
            _playerComponent = Get<PlayerComponent>();
            _accelerateComponent = Get<AccelerateComponent>();
            _inputComponent = Get<InputComponent>();
        }

        public void LateUpdate(int entity)
        {
            if (Filter(entity))
            {
                ref TransformComponent transform = ref _transformComponent.GetComponent(entity);
                ref PlayerComponent player = ref _playerComponent.GetComponent(entity);
                ref AccelerateComponent accelerate = ref _accelerateComponent.GetComponent(entity);
                ref InputComponent inputComponent = ref _inputComponent.GetComponent(entity);
                
                CalculateFactor(ref accelerate, ref player, ref transform, ref inputComponent);
            }
        }

        private void CalculateFactor(ref AccelerateComponent accelerate, ref PlayerComponent player, ref TransformComponent transform, ref InputComponent input)
        {
            accelerate.CurTime += accelerate.IsActivate
                ? Time.deltaTime * accelerate.SlowMultiplier
                : Time.deltaTime * accelerate.FastMultiplier;

            float clampTime = Mathf.Clamp(accelerate.CurTime, 0f, accelerate.MaxTime);
            float time = clampTime / accelerate.MaxTime;

            if (input.IsJoystickHeld)
            {
                if (accelerate.IsActivate)
                {
                    accelerate.Factor = Mathf.Lerp(accelerate.MaxFactor, accelerate.MinFactor, time);
                }
                else
                {
                    float curAngle = CalculateAngle(player, transform);
                    float delta = Mathf.Abs(accelerate.Angle - curAngle);

                    if (delta > accelerate.AngleDetection)
                    {
                        accelerate.IsActivate = true;
                        accelerate.CurTime = CalculateCurrentTime(accelerate.MaxTime, clampTime);
                    }
                }
            }
            else
            {
                if (accelerate.IsActivate)
                {
                    accelerate.IsActivate = false;
                    accelerate.CurTime = CalculateCurrentTime(accelerate.MaxTime, clampTime);
                }
                else
                {
                    accelerate.Angle = CalculateAngle(player, transform);
                    accelerate.Factor = Mathf.Lerp(accelerate.MinFactor, accelerate.MaxFactor, time);
                }
            }
        }

        private float CalculateCurrentTime(float maxTime, float clampTime)
        {
            if (maxTime > clampTime)
            {
                return maxTime - clampTime;
            }

            return 0f;
        }
        private float CalculateAngle(PlayerComponent player, TransformComponent transform)
        {
            Vector3 direction = player.Velocity - transform.Transform.position;

            return Vector3.SignedAngle(transform.Transform.forward, direction, Vector3.up);
        }
    }
}
using Core;
using Core.Components;
using Core.Systems;
using Game.Components;
using UnityEngine;

namespace Game.Systems.Run
{
    public sealed class PlayerMoveRunSystem : RunSystem, IUpdateSystem
    {
        private readonly EntityComponent<TransformComponent> _transformComponent;
        private readonly EntityComponent<PlayerComponent> _playerComponent;
        private readonly EntityComponent<AccelerateComponent> _accelerateComponent;
        private readonly EntityComponent<SpeedComponent> _speedComponent;
        private readonly EntityComponent<InputComponent> _inputComponent;

        public PlayerMoveRunSystem(EcsWorld ecsWorld) : base(ecsWorld)
        {
            _transformComponent = Get<TransformComponent>();
            _playerComponent = Get<PlayerComponent>();
            _accelerateComponent = Get<AccelerateComponent>();
            _speedComponent = Get<SpeedComponent>();
            _inputComponent = Get<InputComponent>();
        }

        public void Update(int entity)
        {
            if (Filter(entity))
            {
                ref TransformComponent transform = ref _transformComponent.GetComponent(entity);
                ref PlayerComponent player = ref _playerComponent.GetComponent(entity);
                ref AccelerateComponent accelerate = ref _accelerateComponent.GetComponent(entity);
                ref SpeedComponent speed = ref _speedComponent.GetComponent(entity);
                ref InputComponent input = ref _inputComponent.GetComponent(entity);

                Move(ref transform, ref player, ref accelerate, ref speed);
                Rotate(ref transform, ref speed, ref input);
            }
        }

        private void Move(ref TransformComponent transform, ref PlayerComponent player, ref AccelerateComponent accelerate, ref SpeedComponent speed)
        {
            player.Velocity = transform.Transform.forward.normalized * speed.MoveSpeed * Time.deltaTime;
            transform.Transform.Translate(player.Velocity * accelerate.Factor, Space.Self);
        }

        private void Rotate(ref TransformComponent transform, ref SpeedComponent speed, ref InputComponent input)
        {
            Vector3 angle = (Vector3.up * input.Value.x + Vector3.left * input.Value.y) * speed.RotationSpeed * Time.deltaTime;
            transform.Transform.Rotate(angle, Space.Self);
            transform.Transform.rotation = Quaternion.Slerp(transform.Transform.rotation, Quaternion.Euler(angle), Time.deltaTime);
        }
    }
}
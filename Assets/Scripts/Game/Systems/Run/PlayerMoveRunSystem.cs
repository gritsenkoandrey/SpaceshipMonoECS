using Core;
using Core.Systems;
using Game.Components;
using UnityEngine;

namespace Game.Systems.Run
{
    public sealed class PlayerMoveRunSystem : RunSystem, IUpdateSystem
    {
        private readonly Filter<TransformComponent, PlayerComponent, AccelerateComponent, SpeedComponent, InputComponent> _filter;

        public PlayerMoveRunSystem(EcsWorld ecsWorld) : base(ecsWorld)
        {
            _filter = new Filter<TransformComponent, PlayerComponent, AccelerateComponent, SpeedComponent, InputComponent>(ecsWorld);
        }

        public void Update(int entity)
        {
            if (_filter.IsFilter(entity))
            {
                ref TransformComponent transform = ref _filter.GetT1(entity);
                ref PlayerComponent player = ref _filter.GetT2(entity);
                ref AccelerateComponent accelerate = ref _filter.GetT3(entity);
                ref SpeedComponent speed = ref _filter.GetT4(entity);
                ref InputComponent input = ref _filter.GetT5(entity);

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
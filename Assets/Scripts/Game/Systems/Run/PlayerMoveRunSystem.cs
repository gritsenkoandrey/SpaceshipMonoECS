using Core;
using Core.Components;
using Core.Systems;
using Dependency.Input;
using Game.Components;
using UnityEngine;

namespace Game.Systems.Run
{
    public sealed class PlayerMoveRunSystem : RunSystem, IUpdateSystem
    {
        private readonly IJoystickService _joystickService;
        
        private readonly EntityComponent<TransformComponent> _transformComponent;
        private readonly EntityComponent<PlayerComponent> _playerComponent;
        
        public PlayerMoveRunSystem(EcsWorld ecsWorld, IJoystickService joystickService) : base(ecsWorld)
        {
            _joystickService = joystickService;
            
            _transformComponent = Get<TransformComponent>();
            _playerComponent = Get<PlayerComponent>();
        }

        public void Update(int entity)
        {
            if (Filter(entity))
            {
                ref TransformComponent transformComponent = ref _transformComponent.GetComponent(entity);
                ref PlayerComponent playerComponent = ref _playerComponent.GetComponent(entity);
                
                Move(transformComponent, playerComponent);
                Rotate(transformComponent, playerComponent);
            }
        }

        private void Move(TransformComponent transform, PlayerComponent player)
        {
            Vector3 forward = transform.Transform.forward.normalized;
            transform.Transform.Translate(forward * player.MoveSpeed * Time.deltaTime, Space.Self);
        }

        private void Rotate(TransformComponent transform, PlayerComponent player)
        {
            Vector3 input = new Vector3(_joystickService.GetValue().x, _joystickService.GetValue().y, 0f);
            Vector3 angle = (Vector3.up * input.x + Vector3.left * input.y) * player.RotationSpeed * Time.deltaTime;
            transform.Transform.Rotate(angle, Space.Self);
            transform.Transform.rotation = Quaternion.Slerp(transform.Transform.rotation, Quaternion.Euler(angle), Time.deltaTime);
        }
    }
}
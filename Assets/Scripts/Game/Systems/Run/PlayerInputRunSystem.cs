using Core;
using Core.Components;
using Core.Systems;
using Dependency.Input;
using Game.Components;
using UnityEngine;

namespace Game.Systems.Run
{
    public sealed class PlayerInputRunSystem : RunSystem, IUpdateSystem
    {
        private readonly IJoystickService _joystickService;
        
        private readonly EntityComponent<PlayerComponent> _playerComponent;
        private readonly EntityComponent<InputComponent> _inputComponent;

        public PlayerInputRunSystem(EcsWorld ecsWorld, IJoystickService joystickService) : base(ecsWorld)
        {
            _joystickService = joystickService;
            
            _playerComponent = Get<PlayerComponent>();
            _inputComponent = Get<InputComponent>();
        }

        public void Update(int entity)
        {
            if (Filter(entity))
            {
                ref InputComponent input = ref _inputComponent.GetComponent(entity);

                UpdateInput(ref input);
            }
        }

        private void UpdateInput(ref InputComponent input)
        {
            input.Value = new Vector3(_joystickService.GetValue().x, _joystickService.GetValue().y, 0f);
            input.IsJoystickHeld = _joystickService.JoystickHeld();
        }
    }
}
using Core;
using Core.Systems;
using Dependency.Input;
using Game.Components;
using UnityEngine;

namespace Game.Systems.Run
{
    public sealed class PlayerInputRunSystem : RunSystem, IUpdateSystem
    {
        private readonly IJoystickService _joystickService;
        private readonly Filter<PlayerComponent, InputComponent> _filter;

        public PlayerInputRunSystem(EcsWorld ecsWorld, IJoystickService joystickService) : base(ecsWorld)
        {
            _filter = new Filter<PlayerComponent, InputComponent>(ecsWorld);
            _joystickService = joystickService;
        }

        public void Update(int entity)
        {
            if (_filter.IsFilter(entity))
            {
                ref InputComponent input = ref _filter.GetT2(entity);

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
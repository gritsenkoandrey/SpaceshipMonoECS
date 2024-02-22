using Core;
using Core.Systems;
using Dependency.Input;
using Game.Components;
using UnityEngine;
using VContainer;

namespace Game.Systems.Run
{
    public sealed class PlayerInputRunSystem : RunSystem, IUpdateSystem
    {
        private readonly Filter<PlayerComponent, InputComponent> _filter;
        
        private IJoystickService _joystickService;

        public PlayerInputRunSystem(EcsWorld ecsWorld) : base(ecsWorld)
        {
            _filter = new Filter<PlayerComponent, InputComponent>(ecsWorld);
        }

        [Inject]
        private void Construct(IJoystickService joystickService)
        {
            _joystickService = joystickService;
        }

        public void Update(int entity)
        {
            if (_filter.Contain(entity))
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
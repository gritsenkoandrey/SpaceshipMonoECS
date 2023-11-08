using System;
using Core;
using Core.Services;
using Dependency.Input;
using Game.Components;
using Game.Systems.Init;
using Game.Systems.Run;
using VContainer;
using VContainer.Unity;

namespace Scope
{
    public sealed class EcsEntryPoint : IInitializable, IStartable, ITickable, IFixedTickable, ILateTickable, IDisposable
    {
        private readonly EcsWorld _ecsWorld;
        private readonly ComponentRegistryService _componentRegistryService;
        private readonly SystemRegistryService _systemRegistryService;

        private readonly IJoystickService _joystickService;

        public EcsEntryPoint(IObjectResolver container)
        {
            _ecsWorld = new EcsWorld();
            _componentRegistryService = _ecsWorld.ComponentRegistryService;
            _systemRegistryService = _ecsWorld.SystemRegistryService;

            _joystickService = container.Resolve<IJoystickService>();
        }
        
        void IInitializable.Initialize()
        {
            _componentRegistryService.RegisterComponent<TransformComponent>();
            _componentRegistryService.RegisterComponent<PlayerComponent>();
            _componentRegistryService.RegisterComponent<PlanetComponent>();
            _componentRegistryService.RegisterComponent<AccelerateComponent>();
            _componentRegistryService.RegisterComponent<InputComponent>();
            _componentRegistryService.RegisterComponent<SpeedComponent>();
            
            _systemRegistryService.RegisterSystem(new PlayerMoveInitSystem(_ecsWorld));
            _systemRegistryService.RegisterSystem(new PlanetMoveInitSystem(_ecsWorld));
            
            _systemRegistryService.RegisterSystem(new PlayerInputRunSystem(_ecsWorld, _joystickService));
            _systemRegistryService.RegisterSystem(new PlayerMoveRunSystem(_ecsWorld));
            _systemRegistryService.RegisterSystem(new PlanetMoveRunSystem(_ecsWorld));
            _systemRegistryService.RegisterSystem(new PlayerAccelerateRunSystem(_ecsWorld));
        }

        void IStartable.Start() => _systemRegistryService.EnableSystem();
        void ITickable.Tick() => _systemRegistryService.Update();
        void IFixedTickable.FixedTick() => _systemRegistryService.FixedUpdate();
        void ILateTickable.LateTick() => _systemRegistryService.LateUpdate();
        void IDisposable.Dispose() => _systemRegistryService.DisableSystem();
    }
}
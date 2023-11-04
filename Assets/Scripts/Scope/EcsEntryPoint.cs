using System;
using Core;
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

        private readonly IJoystickService _joystickService;

        public EcsEntryPoint(IObjectResolver container)
        {
            _ecsWorld = new EcsWorld();

            _joystickService = container.Resolve<IJoystickService>();
        }
        
        void IInitializable.Initialize()
        {
            _ecsWorld.ComponentRegistryService.RegisterComponent<TransformComponent>();
            _ecsWorld.ComponentRegistryService.RegisterComponent<PlayerComponent>();
            _ecsWorld.ComponentRegistryService.RegisterComponent<PlanetComponent>();
            _ecsWorld.ComponentRegistryService.RegisterComponent<AccelerateComponent>();
            _ecsWorld.ComponentRegistryService.RegisterComponent<InputComponent>();
            _ecsWorld.ComponentRegistryService.RegisterComponent<SpeedComponent>();
            
            _ecsWorld.SystemRegistryService.RegisterSystem(new PlayerMoveInitSystem(_ecsWorld));
            _ecsWorld.SystemRegistryService.RegisterSystem(new PlanetMoveInitSystem(_ecsWorld));
            
            _ecsWorld.SystemRegistryService.RegisterSystem(new PlayerInputRunSystem(_ecsWorld, _joystickService));
            _ecsWorld.SystemRegistryService.RegisterSystem(new PlayerMoveRunSystem(_ecsWorld));
            _ecsWorld.SystemRegistryService.RegisterSystem(new PlanetMoveRunSystem(_ecsWorld));
            _ecsWorld.SystemRegistryService.RegisterSystem(new PlayerAccelerateRunSystem(_ecsWorld));
        }

        void IStartable.Start() => _ecsWorld.SystemRegistryService.EnableSystem();
        void ITickable.Tick() => _ecsWorld.SystemRegistryService.Update();
        void IFixedTickable.FixedTick() => _ecsWorld.SystemRegistryService.FixedUpdate();
        void ILateTickable.LateTick() => _ecsWorld.SystemRegistryService.LateUpdate();
        void IDisposable.Dispose() => _ecsWorld.SystemRegistryService.DisableSystem();
    }
}
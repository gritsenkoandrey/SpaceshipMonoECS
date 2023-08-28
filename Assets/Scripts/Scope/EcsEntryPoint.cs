using System;
using AirPlane.Core;
using AirPlane.Dependency.Input;
using AirPlane.Game.Components;
using AirPlane.Game.Systems.Init;
using AirPlane.Game.Systems.Run;
using VContainer;
using VContainer.Unity;

namespace AirPlane.Scope
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
            _ecsWorld.RegisterComponent<TransformComponent>();
            _ecsWorld.RegisterComponent<PlayerComponent>();
            _ecsWorld.RegisterComponent<PlanetComponent>();
            
            _ecsWorld.RegisterSystem(new PlayerMoveInitSystem(_ecsWorld));
            _ecsWorld.RegisterSystem(new PlanetMoveInitSystem(_ecsWorld));
            
            _ecsWorld.RegisterSystem(new PlayerMoveRunSystem(_ecsWorld, _joystickService));
            _ecsWorld.RegisterSystem(new PlanetMoveRunSystem(_ecsWorld));
        }

        void IStartable.Start() => _ecsWorld.EnableSystem();
        void ITickable.Tick() => _ecsWorld.Update();
        void IFixedTickable.FixedTick() => _ecsWorld.FixedUpdate();
        void ILateTickable.LateTick() => _ecsWorld.LateUpdate();
        void IDisposable.Dispose() => _ecsWorld.DisableSystem();
    }
}
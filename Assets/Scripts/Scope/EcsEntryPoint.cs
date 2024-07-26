using System;
using Core;
using Core.Components;
using Core.Systems;
using Game.Components;
using Game.Systems.Init;
using Game.Systems.Run;
using JetBrains.Annotations;
using VContainer;
using VContainer.Unity;

namespace Scope
{
    [UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
    public sealed class EcsEntryPoint : IInitializable, IStartable, ITickable, IFixedTickable, ILateTickable, IDisposable
    {
        private readonly EcsWorld _ecsWorld;
        private readonly IObjectResolver _objectResolver;

        private IComponent[] _components;
        private ISystem[] _systems;

        public EcsEntryPoint(IObjectResolver objectResolver)
        {
            _ecsWorld = new EcsWorld();
            _objectResolver = objectResolver;
        }
        
        void IInitializable.Initialize()
        {
            _components = new IComponent[]
            {
                new EntityComponent<TransformComponent>(),
                new EntityComponent<PlayerComponent>(),
                new EntityComponent<PlanetComponent>(),
                new EntityComponent<AccelerateComponent>(),
                new EntityComponent<InputComponent>(),
                new EntityComponent<SpeedComponent>(),
            };

            RegisterComponents();

            _systems = new ISystem[]
            {
                new PlayerMoveInitSystem(_ecsWorld),
                new PlanetMoveInitSystem(_ecsWorld),
                new PlayerInputRunSystem(_ecsWorld),
                new PlayerMoveRunSystem(_ecsWorld),
                new PlanetMoveRunSystem(_ecsWorld),
                new PlayerAccelerateRunSystem(_ecsWorld),
            };

            RegisterSystems();
        }

        private void RegisterComponents()
        {
            for (int i = 0; i < _components.Length; i++)
            {
                _ecsWorld.ComponentRegistryService.RegisterComponent(_components[i]);
            }
        }

        private void RegisterSystems()
        {
            for (int i = 0; i < _systems.Length; i++)
            {
                _objectResolver.Inject(_systems[i]);

                _ecsWorld.SystemRegistryService.RegisterSystem(_systems[i]);
            }
        }

        void IStartable.Start() => _ecsWorld.SystemRegistryService.EnableSystem();
        void ITickable.Tick() => _ecsWorld.SystemRegistryService.Update(_ecsWorld.EntitiesRegistryService.Entities);
        void IFixedTickable.FixedTick() => _ecsWorld.SystemRegistryService.FixedUpdate(_ecsWorld.EntitiesRegistryService.Entities);
        void ILateTickable.LateTick() => _ecsWorld.SystemRegistryService.LateUpdate(_ecsWorld.EntitiesRegistryService.Entities);
        void IDisposable.Dispose() => _ecsWorld.SystemRegistryService.DisableSystem();
    }
}
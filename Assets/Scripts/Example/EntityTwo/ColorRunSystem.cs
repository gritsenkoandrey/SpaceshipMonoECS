using MonoEcs.Core;
using MonoEcs.Core.Components;
using MonoEcs.Core.Systems;
using MonoEcs.Example.Components;
using UnityEngine;

namespace MonoEcs.Example.EntityTwo
{
    public sealed class ColorRunSystem : RunSystem, IFixedUpdateSystem
    {
        private readonly EntityComponent<DebugOneComponent> _debugOne;

        public ColorRunSystem(EcsWorld ecsWorld) : base(ecsWorld)
        {
            _debugOne = Get<DebugOneComponent>();
        }

        public void FixedUpdate(int entity)
        {
            if (Filter(entity))
            {
                ref DebugOneComponent debugOneComponent = ref _debugOne.GetComponent(entity);

                Debug.Log($"fixed {debugOneComponent.Value}");
            }
        }
    }
}
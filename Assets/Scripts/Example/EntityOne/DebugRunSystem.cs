using MonoEcs.Core;
using MonoEcs.Core.Components;
using MonoEcs.Core.Systems;
using MonoEcs.Example.Components;
using UnityEngine;

namespace MonoEcs.Example.EntityOne
{
    public sealed class DebugRunSystem : RunSystem, IUpdateSystem
    {
        private readonly EntityComponent<DebugOneComponent> _debugOne;
        private readonly EntityComponent<DebugTwoComponent> _debugTwo;

        public DebugRunSystem(EcsWorld ecsWorld) : base(ecsWorld)
        {
            _debugOne = Get<DebugOneComponent>();
            _debugTwo = Get<DebugTwoComponent>();
        }

        public void Update(int entity)
        {
            if (Filter(entity))
            {
                ref DebugOneComponent debugOneComponent = ref _debugOne.GetComponent(entity);
                ref DebugTwoComponent debugTwoComponent = ref _debugTwo.GetComponent(entity);

                Debug.Log($"update {debugOneComponent.Value}");
                Debug.Log($"update {debugTwoComponent.Value}");
            }
        }
    }
}
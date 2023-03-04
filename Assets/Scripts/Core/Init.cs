using System.Collections.Generic;
using AndreyGritsenko.MonoECS.Example;
using UnityEngine;

namespace AndreyGritsenko.MonoECS.Core
{
    [DefaultExecutionOrder(-500)]
    public sealed class Init : MonoBehaviour
    {
        private readonly List<EntitySystem> _systems = new();

        private void Awake() => CreateSystem();
        private void OnEnable() => EnableSystem();
        private void OnDisable() => DisableSystem();
        private void OnDestroy() => _systems.Clear();
        
        private void CreateSystem() => _systems.Add(new ExampleSystem());

        private void EnableSystem()
        {
            foreach (EntitySystem system in _systems)
            {
                system.EnableSystem();
            }
        }

        private void DisableSystem()
        {
            foreach (EntitySystem system in _systems)
            {
                system.DisableSystem();
            }
        }
    }
}

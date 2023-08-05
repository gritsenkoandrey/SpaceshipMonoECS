using System;

namespace MonoEcs.Core.Components
{
    public interface IComponent
    {
        public Type Type { get; }
        public void AddComponent();
        public void RemoveComponent(int entity);
        public bool HasComponent(int entity);
    }
}
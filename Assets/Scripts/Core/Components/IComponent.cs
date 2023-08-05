using System;

namespace MonoEcs.Core.Components
{
    public interface IComponent
    {
        public Type GetTypeComponent();
        public void AddComponent();
        public void RemoveComponent(int entity);
        public bool ContainsComponent(int entity);
    }
}
using System;

namespace AirPlane.Core.Components
{
    public interface IComponent
    {
        public Type GetTypeComponent();
        public void AddComponent();
        public void RemoveComponent(int entity);
        public bool ContainsComponent(int entity);
    }
}
using System.Collections.Generic;
using Core.Components;

namespace Core.Services
{
    public sealed class ComponentRegistryService
    {
        private readonly List<IComponent> _components;
        public IReadOnlyList<IComponent> Components => _components;

        public ComponentRegistryService()
        {
            _components = new List<IComponent>();
        }

        public void RegisterComponent(IComponent component)
        {
            _components.Add(component);
        }

        public void AddComponent()
        {
            for (int i = 0; i < _components.Count; i++)
            {
                _components[i].AddComponent();
            }
        }

        public void RemoveComponent(int entity)
        {
            for (int i = 0; i < _components.Count; i++)
            {
                _components[i].RemoveComponent(entity);
            }
        }
    }
}
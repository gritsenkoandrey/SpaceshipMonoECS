using System;

namespace MonoEcs.Core.Components
{
    public sealed class EntityComponent<T> : IComponent where T : struct
    {
        private int _size;
        private Component[] _components;
        
        public Type Type { get; }

        public EntityComponent(int length)
        {
            Type = typeof(T);
            _size = default;
            _components = new Component[length];
        }

        void IComponent.AddComponent()
        {
            if (_size > _components.Length)
            {
                Array.Resize(ref _components, _components.Length * 2);
            }
        
            _components[_size] = new Component
            {
                Value = default,
                Exists = false,
            };
            
            _size++;
        }

        void IComponent.RemoveComponent(int entity)
        {
            ref var component = ref _components[entity];
            
            component.Exists = false;
        }

        public ref T GetComponent(int entity)
        {
            ref Component component = ref _components[entity];
            
            return ref component.Value;
        }

        public void SetComponent(int entity, ref T value)
        {
            ref var component = ref _components[entity];
            
            component.Value = value;
            component.Exists = true;
        }

        bool IComponent.HasComponent(int entity) => _components[entity].Exists;

        private struct Component
        {
            public T Value;
            public bool Exists;
        }
    }
}
using System;

namespace Core.Components
{
    public sealed class EntityComponent<T> : IComponent where T : struct
    {
        private readonly Type _type;
        private int _size;
        private ComponentValue[] _components;

        public EntityComponent(int length = 16)
        {
            _type = typeof(T);
            _size = 0;
            _components = new ComponentValue[length];
        }

        Type IComponent.GetTypeComponent() => _type;

        void IComponent.AddComponent()
        {
            if (_size > _components.Length)
            {
                Array.Resize(ref _components, _components.Length * 2);
            }
        
            _components[_size] = new ComponentValue
            {
                Value = default,
                Exists = false,
            };
            
            _size++;
        }

        void IComponent.RemoveComponent(int entity)
        {
            ref ComponentValue component = ref _components[entity];
            
            component.Exists = false;
        }

        bool IComponent.ContainsComponent(int entity)
        {
            return _components[entity].Exists;
        }

        public ref T GetComponent(int entity)
        {
            ref ComponentValue component = ref _components[entity];
            
            return ref component.Value;
        }

        public void SetComponent(int entity, ref T value)
        {
            ref ComponentValue component = ref _components[entity];
            
            component.Value = value;
            component.Exists = true;
        }

        private struct ComponentValue
        {
            public T Value;
            public bool Exists;
        }
    }
}
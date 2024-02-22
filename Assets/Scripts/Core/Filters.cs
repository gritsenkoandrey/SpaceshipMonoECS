using System;
using System.Collections.Generic;
using Core.Components;
using Core.Services;

namespace Core
{
    public abstract class BaseFilter
    {
        private readonly ComponentRegistryService _componentRegistryService;
        private readonly IList<IComponent> _components;

        protected BaseFilter(EcsWorld ecsWorld)
        {
            _componentRegistryService = ecsWorld.ComponentRegistryService;
            _components = new List<IComponent>();
        }

        protected EntityComponent<T> Get<T>(Type type) where T : struct
        {
            for (int i = 0; i < _componentRegistryService.Components.Count; i++)
            {
                if (_componentRegistryService.Components[i].GetTypeComponent() == type)
                {
                    _components.Add(_componentRegistryService.Components[i]);
            
                    return (EntityComponent<T>)_componentRegistryService.Components[i];
                }
            }
            
            return null;
        }

        protected ref T Set<T>(EntityComponent<T> entityComponent, int entity) where T : struct
        {
            ref T component = ref entityComponent.GetComponent(entity);
            
            entityComponent.SetComponent(entity, ref component);

            return ref component;
        }

        public bool Contain(int entity)
        {
            for (int i = 0; i < _components.Count; i++)
            {
                if (!_components[i].ContainsComponent(entity))
                {
                    return false;
                }
            }

            return true;
        }
    }

    public sealed class Filter<T1> : BaseFilter
        where T1 : struct
    {
        private readonly EntityComponent<T1> _componentT1;

        public Filter(EcsWorld ecsWorld) : base(ecsWorld)
        {
            _componentT1 = Get<T1>(typeof(T1));
        }

        public ref T1 GetT1(int entity) => ref _componentT1.GetComponent(entity);
        public ref T1 SetT1(int entity) => ref Set(_componentT1, entity);
    }

    public sealed class Filter<T1, T2> : BaseFilter
        where T1 : struct where T2 : struct
    {
        private readonly EntityComponent<T1> _componentT1;
        private readonly EntityComponent<T2> _componentT2;

        public Filter(EcsWorld ecsWorld) : base(ecsWorld)
        {
            _componentT1 = Get<T1>(typeof(T1));
            _componentT2 = Get<T2>(typeof(T2));
        }

        public ref T1 GetT1(int entity) => ref _componentT1.GetComponent(entity);
        public ref T2 GetT2(int entity) => ref _componentT2.GetComponent(entity);
        public ref T1 SetT1(int entity) => ref Set(_componentT1, entity);
        public ref T2 SetT2(int entity) => ref Set(_componentT2, entity);
    }

    public sealed class Filter<T1, T2, T3> : BaseFilter
        where T1 : struct where T2 : struct where T3 : struct
    {
        private readonly EntityComponent<T1> _componentT1;
        private readonly EntityComponent<T2> _componentT2;
        private readonly EntityComponent<T3> _componentT3;

        public Filter(EcsWorld ecsWorld) : base(ecsWorld)
        {
            _componentT1 = Get<T1>(typeof(T1));
            _componentT2 = Get<T2>(typeof(T2));
            _componentT3 = Get<T3>(typeof(T3));
        }

        public ref T1 GetT1(int entity) => ref _componentT1.GetComponent(entity);
        public ref T2 GetT2(int entity) => ref _componentT2.GetComponent(entity);
        public ref T3 GetT3(int entity) => ref _componentT3.GetComponent(entity);
        public ref T1 SetT1(int entity) => ref Set(_componentT1, entity);
        public ref T2 SetT2(int entity) => ref Set(_componentT2, entity);
        public ref T3 SetT3(int entity) => ref Set(_componentT3, entity);
    }

    public sealed class Filter<T1, T2, T3, T4> : BaseFilter
        where T1 : struct where T2 : struct where T3 : struct where T4 : struct
    {
        private readonly EntityComponent<T1> _componentT1;
        private readonly EntityComponent<T2> _componentT2;
        private readonly EntityComponent<T3> _componentT3;
        private readonly EntityComponent<T4> _componentT4;

        public Filter(EcsWorld ecsWorld) : base(ecsWorld)
        {
            _componentT1 = Get<T1>(typeof(T1));
            _componentT2 = Get<T2>(typeof(T2));
            _componentT3 = Get<T3>(typeof(T3));
            _componentT4 = Get<T4>(typeof(T4));
        }

        public ref T1 GetT1(int entity) => ref _componentT1.GetComponent(entity);
        public ref T2 GetT2(int entity) => ref _componentT2.GetComponent(entity);
        public ref T3 GetT3(int entity) => ref _componentT3.GetComponent(entity);
        public ref T4 GetT4(int entity) => ref _componentT4.GetComponent(entity);
        public ref T1 SetT1(int entity) => ref Set(_componentT1, entity);
        public ref T2 SetT2(int entity) => ref Set(_componentT2, entity);
        public ref T3 SetT3(int entity) => ref Set(_componentT3, entity);
        public ref T4 SetT4(int entity) => ref Set(_componentT4, entity);
    }

    public sealed class Filter<T1, T2, T3, T4, T5> : BaseFilter
        where T1 : struct where T2 : struct where T3 : struct where T4 : struct where T5 : struct
    {
        private readonly EntityComponent<T1> _componentT1;
        private readonly EntityComponent<T2> _componentT2;
        private readonly EntityComponent<T3> _componentT3;
        private readonly EntityComponent<T4> _componentT4;
        private readonly EntityComponent<T5> _componentT5;

        public Filter(EcsWorld ecsWorld) : base(ecsWorld)
        {
            _componentT1 = Get<T1>(typeof(T1));
            _componentT2 = Get<T2>(typeof(T2));
            _componentT3 = Get<T3>(typeof(T3));
            _componentT4 = Get<T4>(typeof(T4));
            _componentT5 = Get<T5>(typeof(T5));
        }

        public ref T1 GetT1(int entity) => ref _componentT1.GetComponent(entity);
        public ref T2 GetT2(int entity) => ref _componentT2.GetComponent(entity);
        public ref T3 GetT3(int entity) => ref _componentT3.GetComponent(entity);
        public ref T4 GetT4(int entity) => ref _componentT4.GetComponent(entity);
        public ref T5 GetT5(int entity) => ref _componentT5.GetComponent(entity);
        public ref T1 SetT1(int entity) => ref Set(_componentT1, entity);
        public ref T2 SetT2(int entity) => ref Set(_componentT2, entity);
        public ref T3 SetT3(int entity) => ref Set(_componentT3, entity);
        public ref T4 SetT4(int entity) => ref Set(_componentT4, entity);
        public ref T5 SetT5(int entity) => ref Set(_componentT5, entity);
    }
    
    public sealed class Filter<T1, T2, T3, T4, T5, T6> : BaseFilter
        where T1 : struct where T2 : struct where T3 : struct where T4 : struct where T5 : struct where T6 : struct
    {
        private readonly EntityComponent<T1> _componentT1;
        private readonly EntityComponent<T2> _componentT2;
        private readonly EntityComponent<T3> _componentT3;
        private readonly EntityComponent<T4> _componentT4;
        private readonly EntityComponent<T5> _componentT5;
        private readonly EntityComponent<T6> _componentT6;

        public Filter(EcsWorld ecsWorld) : base(ecsWorld)
        {
            _componentT1 = Get<T1>(typeof(T1));
            _componentT2 = Get<T2>(typeof(T2));
            _componentT3 = Get<T3>(typeof(T3));
            _componentT4 = Get<T4>(typeof(T4));
            _componentT5 = Get<T5>(typeof(T5));
            _componentT6 = Get<T6>(typeof(T6));
        }

        public ref T1 GetT1(int entity) => ref _componentT1.GetComponent(entity);
        public ref T2 GetT2(int entity) => ref _componentT2.GetComponent(entity);
        public ref T3 GetT3(int entity) => ref _componentT3.GetComponent(entity);
        public ref T4 GetT4(int entity) => ref _componentT4.GetComponent(entity);
        public ref T5 GetT5(int entity) => ref _componentT5.GetComponent(entity);
        public ref T6 GetT6(int entity) => ref _componentT6.GetComponent(entity);
        public ref T1 SetT1(int entity) => ref Set(_componentT1, entity);
        public ref T2 SetT2(int entity) => ref Set(_componentT2, entity);
        public ref T3 SetT3(int entity) => ref Set(_componentT3, entity);
        public ref T4 SetT4(int entity) => ref Set(_componentT4, entity);
        public ref T5 SetT5(int entity) => ref Set(_componentT5, entity);
        public ref T6 SetT6(int entity) => ref Set(_componentT6, entity);
    }
    
    public sealed class Filter<T1, T2, T3, T4, T5, T6, T7> : BaseFilter
        where T1 : struct where T2 : struct where T3 : struct where T4 : struct where T5 : struct where T6 : struct where T7 : struct
    {
        private readonly EntityComponent<T1> _componentT1;
        private readonly EntityComponent<T2> _componentT2;
        private readonly EntityComponent<T3> _componentT3;
        private readonly EntityComponent<T4> _componentT4;
        private readonly EntityComponent<T5> _componentT5;
        private readonly EntityComponent<T6> _componentT6;
        private readonly EntityComponent<T7> _componentT7;

        public Filter(EcsWorld ecsWorld) : base(ecsWorld)
        {
            _componentT1 = Get<T1>(typeof(T1));
            _componentT2 = Get<T2>(typeof(T2));
            _componentT3 = Get<T3>(typeof(T3));
            _componentT4 = Get<T4>(typeof(T4));
            _componentT5 = Get<T5>(typeof(T5));
            _componentT6 = Get<T6>(typeof(T6));
            _componentT7 = Get<T7>(typeof(T7));
        }

        public ref T1 GetT1(int entity) => ref _componentT1.GetComponent(entity);
        public ref T2 GetT2(int entity) => ref _componentT2.GetComponent(entity);
        public ref T3 GetT3(int entity) => ref _componentT3.GetComponent(entity);
        public ref T4 GetT4(int entity) => ref _componentT4.GetComponent(entity);
        public ref T5 GetT5(int entity) => ref _componentT5.GetComponent(entity);
        public ref T6 GetT6(int entity) => ref _componentT6.GetComponent(entity);
        public ref T7 GetT7(int entity) => ref _componentT7.GetComponent(entity);
        public ref T1 SetT1(int entity) => ref Set(_componentT1, entity);
        public ref T2 SetT2(int entity) => ref Set(_componentT2, entity);
        public ref T3 SetT3(int entity) => ref Set(_componentT3, entity);
        public ref T4 SetT4(int entity) => ref Set(_componentT4, entity);
        public ref T5 SetT5(int entity) => ref Set(_componentT5, entity);
        public ref T6 SetT6(int entity) => ref Set(_componentT6, entity);
        public ref T7 SetT7(int entity) => ref Set(_componentT7, entity);
    }
    
    public sealed class Filter<T1, T2, T3, T4, T5, T6, T7, T8> : BaseFilter
        where T1 : struct where T2 : struct where T3 : struct where T4 : struct where T5 : struct where T6 : struct where T7 : struct where T8 : struct
    {
        private readonly EntityComponent<T1> _componentT1;
        private readonly EntityComponent<T2> _componentT2;
        private readonly EntityComponent<T3> _componentT3;
        private readonly EntityComponent<T4> _componentT4;
        private readonly EntityComponent<T5> _componentT5;
        private readonly EntityComponent<T6> _componentT6;
        private readonly EntityComponent<T7> _componentT7;
        private readonly EntityComponent<T8> _componentT8;

        public Filter(EcsWorld ecsWorld) : base(ecsWorld)
        {
            _componentT1 = Get<T1>(typeof(T1));
            _componentT2 = Get<T2>(typeof(T2));
            _componentT3 = Get<T3>(typeof(T3));
            _componentT4 = Get<T4>(typeof(T4));
            _componentT5 = Get<T5>(typeof(T5));
            _componentT6 = Get<T6>(typeof(T6));
            _componentT7 = Get<T7>(typeof(T7));
            _componentT8 = Get<T8>(typeof(T8));
        }

        public ref T1 GetT1(int entity) => ref _componentT1.GetComponent(entity);
        public ref T2 GetT2(int entity) => ref _componentT2.GetComponent(entity);
        public ref T3 GetT3(int entity) => ref _componentT3.GetComponent(entity);
        public ref T4 GetT4(int entity) => ref _componentT4.GetComponent(entity);
        public ref T5 GetT5(int entity) => ref _componentT5.GetComponent(entity);
        public ref T6 GetT6(int entity) => ref _componentT6.GetComponent(entity);
        public ref T7 GetT7(int entity) => ref _componentT7.GetComponent(entity);
        public ref T8 GetT8(int entity) => ref _componentT8.GetComponent(entity);
        public ref T1 SetT1(int entity) => ref Set(_componentT1, entity);
        public ref T2 SetT2(int entity) => ref Set(_componentT2, entity);
        public ref T3 SetT3(int entity) => ref Set(_componentT3, entity);
        public ref T4 SetT4(int entity) => ref Set(_componentT4, entity);
        public ref T5 SetT5(int entity) => ref Set(_componentT5, entity);
        public ref T6 SetT6(int entity) => ref Set(_componentT6, entity);
        public ref T7 SetT7(int entity) => ref Set(_componentT7, entity);
        public ref T8 SetT8(int entity) => ref Set(_componentT8, entity);
    }
    
    public sealed class Filter<T1, T2, T3, T4, T5, T6, T7, T8, T9> : BaseFilter
        where T1 : struct where T2 : struct where T3 : struct where T4 : struct where T5 : struct where T6 : struct where T7 : struct where T8 : struct where T9 : struct
    {
        private readonly EntityComponent<T1> _componentT1;
        private readonly EntityComponent<T2> _componentT2;
        private readonly EntityComponent<T3> _componentT3;
        private readonly EntityComponent<T4> _componentT4;
        private readonly EntityComponent<T5> _componentT5;
        private readonly EntityComponent<T6> _componentT6;
        private readonly EntityComponent<T7> _componentT7;
        private readonly EntityComponent<T8> _componentT8;
        private readonly EntityComponent<T9> _componentT9;

        public Filter(EcsWorld ecsWorld) : base(ecsWorld)
        {
            _componentT1 = Get<T1>(typeof(T1));
            _componentT2 = Get<T2>(typeof(T2));
            _componentT3 = Get<T3>(typeof(T3));
            _componentT4 = Get<T4>(typeof(T4));
            _componentT5 = Get<T5>(typeof(T5));
            _componentT6 = Get<T6>(typeof(T6));
            _componentT7 = Get<T7>(typeof(T7));
            _componentT8 = Get<T8>(typeof(T8));
            _componentT9 = Get<T9>(typeof(T9));
        }

        public ref T1 GetT1(int entity) => ref _componentT1.GetComponent(entity);
        public ref T2 GetT2(int entity) => ref _componentT2.GetComponent(entity);
        public ref T3 GetT3(int entity) => ref _componentT3.GetComponent(entity);
        public ref T4 GetT4(int entity) => ref _componentT4.GetComponent(entity);
        public ref T5 GetT5(int entity) => ref _componentT5.GetComponent(entity);
        public ref T6 GetT6(int entity) => ref _componentT6.GetComponent(entity);
        public ref T7 GetT7(int entity) => ref _componentT7.GetComponent(entity);
        public ref T8 GetT8(int entity) => ref _componentT8.GetComponent(entity);
        public ref T9 GetT9(int entity) => ref _componentT9.GetComponent(entity);
        public ref T1 SetT1(int entity) => ref Set(_componentT1, entity);
        public ref T2 SetT2(int entity) => ref Set(_componentT2, entity);
        public ref T3 SetT3(int entity) => ref Set(_componentT3, entity);
        public ref T4 SetT4(int entity) => ref Set(_componentT4, entity);
        public ref T5 SetT5(int entity) => ref Set(_componentT5, entity);
        public ref T6 SetT6(int entity) => ref Set(_componentT6, entity);
        public ref T7 SetT7(int entity) => ref Set(_componentT7, entity);
        public ref T8 SetT8(int entity) => ref Set(_componentT8, entity);
        public ref T9 SetT9(int entity) => ref Set(_componentT9, entity);
    }
}
using AndreyGritsenko.MonoECS.Core;
using UnityEngine;

namespace AndreyGritsenko.MonoECS.Example
{
    public sealed class ExampleSystem : SystemComponent<ExampleComponent>
    {
        protected override void OnEnableSystem()
        {
            base.OnEnableSystem();
        }

        protected override void OnDisableSystem()
        {
            base.OnDisableSystem();
        }

        protected override void OnEnableComponent(ExampleComponent component)
        {
            base.OnEnableComponent(component);
            
            Run(component);
        }

        protected override void OnDisableComponent(ExampleComponent component)
        {
            base.OnDisableComponent(component);
        }
        
        private void Run(ExampleComponent component)
        {
            Vector3 pos = component.transform.position;
            
            for (int i = 0; i < component.Count; i++)
            {
                float x = GetX(component, i);
                float y = GetY(component, i);
                float z = GetZ(component, i);
                
                Vector3 offset = new Vector3(pos.x + x, pos.y + y, pos.z + z);
                
                Object.Instantiate(component.Prefab, offset, Quaternion.identity, component.transform);
            }
        }

        private float GetX(ExampleComponent component, int count) => count % component.RowX * component.Offset;
        private float GetY(ExampleComponent component, int count) => Mathf.Floor(count / (component.RowX * component.RowZ)) * component.Offset;
        private float GetZ(ExampleComponent component, int count) => Mathf.Floor(count % (component.RowX * component.RowZ) / component.RowZ) * component.Offset;
    }
}
using MonoEcs.Core.Entities;
using UnityEngine;

namespace MonoEcs.Example.EntityOne
{
    public sealed class DebugEntity : Entity<DebugEntity>
    {
        public int Index;
        public Vector3 Vector;
        
        protected override void OnEntityCreate()
        {
            base.OnEntityCreate();
        }

        protected override void OnEntityEnable()
        {
            base.OnEntityEnable();
        }

        protected override void OnEntityDisable()
        {
            base.OnEntityDisable();
        }
    }
}
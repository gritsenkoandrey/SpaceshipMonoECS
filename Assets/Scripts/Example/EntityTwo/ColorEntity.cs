using MonoEcs.Core.Entities;
using UnityEngine;

namespace MonoEcs.Example.EntityTwo
{
    public sealed class ColorEntity : Entity<ColorEntity>
    {
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
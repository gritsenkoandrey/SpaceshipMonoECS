using MonoEcs.Core.Entities;

namespace MonoEcs.Example.EntityOne
{
    public sealed class DebugEntity : Entity<DebugEntity>
    {
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
using System.Collections.Generic;

namespace AndreyGritsenko.MonoECS.Core
{
    public abstract class EntitySystem
    {
        protected readonly HashSet<Entity> Entities = new();
        public void EnableSystem() => OnEnableSystem();
        public void DisableSystem() => OnDisableSystem();
        protected virtual void OnEnableSystem() { }
        protected virtual void OnDisableSystem() => Entities.Clear();
    }
}
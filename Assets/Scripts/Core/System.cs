using System.Collections.Generic;

namespace AndreyGritsenko.MonoECS.Core
{
    public abstract class System
    {
        protected readonly HashSet<Entity> Entities;
        protected System() => Entities = new HashSet<Entity>();

        public void EnableSystem() => OnEnableSystem();
        public void DisableSystem() => OnDisableSystem();
        
        protected virtual void OnEnableSystem() { }
        protected virtual void OnDisableSystem() => Entities.Clear();
    }
}
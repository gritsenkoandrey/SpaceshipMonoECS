using AirPlane.Core.Entities;
using UnityEngine;

namespace AirPlane.Game.Entities
{
    public sealed class PlanetEntity : Entity<PlanetEntity>
    {
        public Transform Center;
        
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
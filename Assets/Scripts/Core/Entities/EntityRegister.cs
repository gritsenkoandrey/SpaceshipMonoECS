using System;

namespace AirPlane.Core.Entities
{
    public static class EntityRegister<T> where T : EntityBase
    {
        public static Action<T> OnRegistered;
        public static Action<T> OnUnregistered;
    }
}
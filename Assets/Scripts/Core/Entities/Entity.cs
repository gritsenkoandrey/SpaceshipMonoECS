namespace AirPlane.Core.Entities
{
    public abstract class Entity<T> : EntityBase where T : EntityBase
    {
        private void Awake()
        {
            OnEntityCreate();
        }

        private void OnEnable()
        {
            OnEntityEnable();
            
            EntityRegister<T>.OnRegistered?.Invoke(this as T);
        }

        private void OnDisable()
        {
            OnEntityDisable();
            
            EntityRegister<T>.OnUnregistered?.Invoke(this as T);
        }
    }
}
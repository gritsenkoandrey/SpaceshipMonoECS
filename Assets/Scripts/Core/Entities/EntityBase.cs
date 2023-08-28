using UnityEngine;

namespace Core.Entities
{
    public abstract class EntityBase : MonoBehaviour
    {
        public int Id { get; private set; }
        public void SetId(int id) => Id = id;
        
        protected virtual void OnEntityCreate() { }
        protected virtual void OnEntityEnable() { }
        protected virtual void OnEntityDisable() { }
    }
}
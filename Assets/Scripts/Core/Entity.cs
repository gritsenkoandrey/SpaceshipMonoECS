using UnityEngine;

namespace AndreyGritsenko.MonoECS.Core
{
    public abstract class Entity : MonoBehaviour
    {
        protected virtual void OnEntityCreate() { }
        protected virtual void OnEntityEnable() { }
        protected virtual void OnEntityDisable() { }
    }
}
using UnityEngine;

namespace Dependency.Input
{
    public interface IJoystickService
    {
        public Vector2 GetValue();
        public void Init();
        public void Enable(bool isEnable);
        public void Execute();
    }
}
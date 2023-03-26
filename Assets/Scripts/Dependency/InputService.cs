using UnityEngine;

namespace AndreyGritsenko.MonoECS.Dependency
{
    public sealed class InputService : IInputService
    {
        public Vector2 Vector { get; }

        public InputService()
        {
            Vector = Vector2.one;
        }
    }
}
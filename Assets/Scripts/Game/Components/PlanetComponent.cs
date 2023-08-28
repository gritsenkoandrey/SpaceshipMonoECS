using UnityEngine;

namespace Game.Components
{
    public struct PlanetComponent
    {
        public Transform Center;
        
        public float CurrentOrbitAngle;
        public float CurrentRotateAngle;
        public float DistanceToCenter;
        public float Sin;
        public float Cos;
        public float Speed;
    }
}
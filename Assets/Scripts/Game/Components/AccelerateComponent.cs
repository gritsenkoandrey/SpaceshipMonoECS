namespace Game.Components
{
    public struct AccelerateComponent
    {
        public float Angle;
        public float AngleDetection;
        public float CurTime;
        public float MaxTime;
        public float MaxFactor;
        public float MinFactor;
        public float FastMultiplier;
        public float SlowMultiplier;
        public float Factor;
        
        public bool IsActivate;
    }
}
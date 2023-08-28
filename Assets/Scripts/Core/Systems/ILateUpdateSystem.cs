namespace AirPlane.Core.Systems
{
    public interface ILateUpdateSystem : IRunSystem
    {
        public void LateUpdate(int entity);
    }
}
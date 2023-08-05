namespace MonoEcs.Core.Systems
{
    public interface ILateUpdateSystem : IRunSystem
    {
        public void LateUpdate(int entity);
    }
}
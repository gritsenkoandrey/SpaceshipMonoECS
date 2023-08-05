namespace MonoEcs.Core.Systems
{
    public interface IFixedUpdateSystem : IRunSystem
    {
        public void FixedUpdate(int entity);
    }
}
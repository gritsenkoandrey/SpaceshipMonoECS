namespace MonoEcs.Core.Systems
{
    public interface IUpdateSystem : IRunSystem
    {
        public void Update(int entity);
    }
}
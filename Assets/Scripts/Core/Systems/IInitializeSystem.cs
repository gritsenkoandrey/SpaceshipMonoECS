namespace Core.Systems
{
    public interface IInitializeSystem : ISystem
    {
        public void OnEnableSystem();
        public void OnDisableSystem();
    }
}
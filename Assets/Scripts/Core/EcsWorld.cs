using Core.Services;

namespace Core
{
    public sealed class EcsWorld
    {
        public ComponentRegistryService ComponentRegistryService { get; }
        public SystemRegistryService SystemRegistryService { get; }
        public EntitiesRegistryService EntitiesRegistryService { get; }

        public EcsWorld()
        {
            ComponentRegistryService = new ComponentRegistryService();
            EntitiesRegistryService = new EntitiesRegistryService(ComponentRegistryService);
            SystemRegistryService = new SystemRegistryService(EntitiesRegistryService);
        }
    }
}
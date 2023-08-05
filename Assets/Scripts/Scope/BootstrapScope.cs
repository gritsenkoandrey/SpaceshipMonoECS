using MonoEcs.Dependency.Loader;
using MonoEcs.Dependency.StateMachine;
using VContainer;
using VContainer.Unity;

namespace MonoEcs.Scope
{
    public sealed class BootstrapScope : LifetimeScope
    {
        protected override void Awake()
        {
            base.Awake();
            
            DontDestroyOnLoad(this);
        }

        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<ISceneLoader, SceneLoader>(Lifetime.Singleton);
            builder.Register<IGameStateMachine, GameStateMachine>(Lifetime.Singleton);

            builder.RegisterEntryPoint<EcsEntryPoint>().Build();
            builder.RegisterEntryPoint<BootstrapEntryPoint>().Build();
        }
    }
}
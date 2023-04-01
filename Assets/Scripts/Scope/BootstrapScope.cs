using AndreyGritsenko.MonoECS.Dependency.Input;
using AndreyGritsenko.MonoECS.Dependency.Loader;
using AndreyGritsenko.MonoECS.Dependency.StateMachine;
using VContainer;
using VContainer.Unity;

namespace AndreyGritsenko.MonoECS.Scope
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
            builder.Register<IInputService, InputService>(Lifetime.Singleton);
            builder.Register<ISceneLoader, SceneLoader>(Lifetime.Singleton);
            builder.Register<IGameStateMachine, GameStateMachine>(Lifetime.Singleton);

            builder.RegisterEntryPoint<BootstrapEntryPoint>().Build();
        }
    }
}
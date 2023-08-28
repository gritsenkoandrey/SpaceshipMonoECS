using AirPlane.Dependency.Input;
using AirPlane.Dependency.Loader;
using AirPlane.Dependency.StateMachine;
using VContainer;
using VContainer.Unity;

namespace AirPlane.Scope
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
            builder.RegisterComponentInHierarchy<JoystickService>().As<IJoystickService>();
            
            builder.Register<ISceneLoader, SceneLoader>(Lifetime.Singleton);
            builder.Register<IGameStateMachine, GameStateMachine>(Lifetime.Singleton);

            builder.RegisterEntryPoint<EcsEntryPoint>().Build();
            builder.RegisterEntryPoint<BootstrapEntryPoint>().Build();
        }
    }
}
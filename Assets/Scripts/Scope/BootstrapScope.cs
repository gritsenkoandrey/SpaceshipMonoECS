using AndreyGritsenko.MonoECS.Dependency;
using UnityEngine.SceneManagement;
using VContainer;
using VContainer.Unity;

namespace AndreyGritsenko.MonoECS.Scope
{
    public sealed class BootstrapScope : LifetimeScope
    {
        private const string GameScene = "Game";
        
        protected override void Awake()
        {
            base.Awake();
            
            DontDestroyOnLoad(this);
        }

        private void Start()
        {
            SceneManager.LoadSceneAsync(GameScene);
        }

        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<IInputService, InputService>(Lifetime.Singleton);

            builder.RegisterEntryPoint<BootstrapEntryPoint>().Build();
        }
    }
}
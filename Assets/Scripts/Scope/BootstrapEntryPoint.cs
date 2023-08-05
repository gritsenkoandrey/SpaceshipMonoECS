using MonoEcs.Dependency.Loader;
using MonoEcs.Dependency.StateMachine;
using VContainer;
using VContainer.Unity;

namespace MonoEcs.Scope
{
    public sealed class BootstrapEntryPoint : IStartable
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly IGameStateMachine _gameStateMachine;
        
        public BootstrapEntryPoint(IObjectResolver container)
        {
            _sceneLoader = container.Resolve<ISceneLoader>();
            _gameStateMachine = container.Resolve<IGameStateMachine>();
        }
        
        void IStartable.Start() => _gameStateMachine.Enter<StateBootstrap>();
    }
}
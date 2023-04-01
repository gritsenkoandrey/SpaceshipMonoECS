using System;

namespace AndreyGritsenko.MonoECS.Dependency.Loader
{
    public interface ISceneLoader
    {
        public void Load(string name, Action onLoaded = null);
    }
}
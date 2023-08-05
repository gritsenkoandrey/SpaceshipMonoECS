using System;

namespace MonoEcs.Dependency.Loader
{
    public interface ISceneLoader
    {
        public void Load(string name, Action onLoaded = null);
    }
}
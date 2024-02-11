using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Dependency.Loader
{
    [UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
    public sealed class SceneLoader : ISceneLoader
    {
        void ISceneLoader.Load(string name, Action onLoaded)
        {
            LoadScene(name, onLoaded);
        }
        
        private async void LoadScene(string name, Action onLoaded = null)
        {
            if (SceneManager.GetActiveScene().name == name)
            {
                onLoaded?.Invoke();
                
                return;
            }
            
            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(name);

            while (!waitNextScene.isDone)
            {
                await Task.Yield();
            }
            
            onLoaded?.Invoke();
        }
    }
}
using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AndreyGritsenko.MonoECS.Dependency.Loader
{
    public sealed class SceneLoader : ISceneLoader
    {
        public void Load(string name, Action onLoaded = null)
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
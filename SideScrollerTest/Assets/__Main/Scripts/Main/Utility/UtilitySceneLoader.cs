using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utility
{

    public interface IUtilitySceneLoader
    {
        void LoadScene(string sceneName, string additive = null);
    }

    public class UtilitySceneLoader: IUtilitySceneLoader
    {
        public void LoadScene(string sceneName, string additive = null)
        {
            SceneManager.LoadScene(sceneName);
            if (additive is null) return;
            SceneManager.LoadScene(additive, LoadSceneMode.Additive);
        }
    }
}
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader
{

    public static string lastSceneName = "";

    /// <summary>
    /// Load a scene asynchronously with a loading bar
    /// </summary>
    /// <param name="sceneName">The name of the scene to load</param>
    /// <param name="saveCurrentSceneName">If true, the current scene name will be saved to be loaded later. Used to kwow to what scene return when entering a minigame</param>
    
    public static void LoadSceneAsyncWithLoadingBar(string sceneName, bool saveCurrentSceneName = false)
    {
        if (saveCurrentSceneName)
        {
            lastSceneName = SceneManager.GetActiveScene().name;
        }
        //Instantiate the loading bar
        SceneLoaderGameObject loadingBar = GameObject.Instantiate(Resources.Load<SceneLoaderGameObject>("Prefabs/LoadingScreen"));
        //Load scene async
        loadingBar.StartLoading(sceneName);
    }

    /// <summary>
    /// DEPRECATED Load a scene directly
    /// </summary>
    public static void LoadSceneDirectly(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }


}

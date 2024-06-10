using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader
{

    //This is static so it can be called from anywhere. Because of this, the loading bar is loaded from resources not from the scene editor panels.
    public static void LoadSceneAsyncWithLoadingBar(string sceneName)
    {
        //Instantiate the loading bar
        SceneLoaderGameObject loadingBar = GameObject.Instantiate(Resources.Load<SceneLoaderGameObject>("Prefabs/LoadingScreen"));
        //Load scene async
        loadingBar.StartLoading(sceneName);
    }

    public static void LoadSceneDirectly(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }


}

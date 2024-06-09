using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader
{
    public static void LoadSceneAsyncWithLoadingBar(string sceneName)
    {
        //Instantiate the loading bar
        SceneLoaderGameObject loadingBar = GameObject.Instantiate(Resources.Load<SceneLoaderGameObject>("MainMenu/LoadingScreen"));
        //Load scene async
        loadingBar.StartLoading(sceneName);
    }

    public static void LoadSceneDirectly(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }


}

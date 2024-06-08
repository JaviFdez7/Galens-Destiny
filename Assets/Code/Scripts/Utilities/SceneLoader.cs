using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader
{
    public static void LoadSceneOnClick(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
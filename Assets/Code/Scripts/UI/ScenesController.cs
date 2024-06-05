using UnityEngine;
using UnityEngine.SceneManagement;

public static class ScenesController {
    public static void LoadScene(string sceneName) {
        // Gets the loading screen from resources
        GameObject loadingScreen = Resources.Load<GameObject>("Menu/LoadingScreen");
        // Instantiates the loading screen
        GameObject loadingScreenInstance = Object.Instantiate(loadingScreen);

        // Load async the scene
        SceneManager.LoadSceneAsync(sceneName).completed += (AsyncOperation operation) => {
            // Destroy the loading screen
            Object.Destroy(loadingScreenInstance);
        };
      
    }
}
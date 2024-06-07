using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingBarMenu : MonoBehaviour
{
    //TODO FIX THIS SCRIPT
    public int minimunDelayInSeconds = 3;
    public float delaySliderValue = 0f;
    public void StartLoading(string sceneName)
    {
        StartCoroutine(LoadScene(sceneName));
    }

    IEnumerator LoadScene(string sceneName)
    {
        //Load scene async, it should update a slider value, if its too fast it will be a delaySliderValue and the value should
        //be the minimun between the delaySliderValue and the progress of the asyncLoad

        //Load the scene async
        AsyncOperation asyncLoad = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);

        //While the scene is loading
        while (!asyncLoad.isDone || delaySliderValue < 1)
        {
            //Update the slider value
            yield return null;
        }
        
    }
}

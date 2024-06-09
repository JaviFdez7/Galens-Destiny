using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


//This script should be attached to a GameObject with a Slider component,
// can be instantiated from another script and should be able to load a scene async.
public class LoadingBarManager : SceneLoaderGameObject 
{
    public Slider slider;
    public float MinimunSecondsOfLoad = 2.0f;
    public override void StartLoading(string sceneName)
    {
        StartCoroutine(LoadScene(sceneName));

    }
        //     float elapsedTime = 0;
        // float fakeProgress = 0;
    // void Update()
    // {
    //         if (elapsedTime < MinimunSecondsOfLoad)
    //             {
    //                 elapsedTime += Time.deltaTime;
    //                 fakeProgress = Mathf.Clamp01(elapsedTime / MinimunSecondsOfLoad);
    //             }


    //         slider.value = Mathf.Min( fakeProgress);
    // }
    IEnumerator LoadScene(string sceneName)
    {
        //Load scene async, it should update a slider value, if its too fast it will be a delaySliderValue and the value should
        //be the minimun between the delaySliderValue and the progress of the asyncLoad

        //Load the scene async
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);
        asyncOperation.allowSceneActivation = false;
        float elapsedTime = 0;

        //While the scene is loading
        while (slider.value <= 1 ){
            //Update the slider value
            float realProgress = Mathf.Clamp01(asyncOperation.progress / 0.9f); 
            elapsedTime += Time.deltaTime;
            float fakeProgress = Mathf.Clamp01(elapsedTime / MinimunSecondsOfLoad);
            slider.value =  Mathf.Min(realProgress, fakeProgress);
            if (elapsedTime > MinimunSecondsOfLoad)
                {
                asyncOperation.allowSceneActivation = true;
                }

            yield return null;
        }
        
    }
}

public abstract class SceneLoaderGameObject: MonoBehaviour
{
    public abstract void StartLoading(string sceneName);
}
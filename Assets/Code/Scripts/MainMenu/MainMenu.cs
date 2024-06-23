using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame() {
        SceneManager.LoadScene("MainGame");
    }
    public void QuitGame(){
        Application.Quit();
    }

    public void Awake()
    {
        LocalizationSettings.InitializationOperation.WaitForCompletion();
    }
    public void Start()
    {
        // Load the selected language from the settings file
        SettingsManager.Deserialize();
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[SettingsManager.LanguageIndex];
    }

}

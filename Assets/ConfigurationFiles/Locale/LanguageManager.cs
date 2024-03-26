using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization.Settings;
using TMPro;
using System.IO;

public class LanguageManager : MonoBehaviour
{
    // Button TMPro prefab
    public GameObject buttonPrefab;
    private Dictionary<int,string> flagPaths = new Dictionary<int,string>{
        {0, Path.Combine("CountryFlags", "us")},
        {1, Path.Combine("CountryFlags", "es")}
    };
    void Start()
    {
        InstantiateButtons();
    }

    // Instantiate buttons with the text of the available languages
    void InstantiateButtons()
    {
        for (int i = 0; i < LocalizationSettings.AvailableLocales.Locales.Count; i++)
        {
            GameObject buttonGO = Instantiate(buttonPrefab, transform);
            
            // Set button text
            buttonGO.GetComponentInChildren<TextMeshProUGUI>().text = LocalizationSettings.AvailableLocales.Locales[i].LocaleName.Split(' ')[0];
            // Set button flag image
            Image flagImage = buttonGO.transform.Find("FlagImage").GetComponent<Image>();

            flagImage.sprite = Resources.Load<Sprite>(flagPaths[i]); // Load flag sprite based on language index
            // Add listener to the button to set locale when clicked
            int localeIndex = i; // Create a local variable to capture the current value of 'i'
            Button button = buttonGO.GetComponent<Button>();
            button.onClick.AddListener(() => SetLocale(localeIndex)); // Use the captured value
        }
    }

    // Set the locale of the game
    public void SetLocale(int localeId)
    {
        Debug.Log("SetLocale: " + localeId);
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[localeId];

        // Save the selected locale to a file

        PersistenceManager.SerializeData("locale", LocalizationSettings.SelectedLocale);
    }

}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SavedGamesManager : MonoBehaviour
{

    public Button buttonPrefab;
    // Start is called before the first frame update
    void Start()
    {
        GameData.Deserialize();
        InstantiateButtons();
    }

    void InstantiateButtons()
    {
        // populate the list to test the UI
        SavedGame g = new SavedGame { Name = "Game 1", Date = "01/01/2021", worldMapId = "1" };
        for (int i = 0; i < 10; i++)
        {
            GameData.SavedGames.Add(g);
        }
        for (int i = 0; i < GameData.SavedGames.Count; i++)
        {
            Button buttonGO = Instantiate(buttonPrefab, transform);
            buttonGO.GetComponentInChildren<TextMeshProUGUI>().text = GameData.SavedGames[i].Name;
            int savedGameIndex = i;
            buttonGO.onClick.AddListener(() => GameData.CurrentSavedGameIndex = savedGameIndex);
            
        }
    }


}
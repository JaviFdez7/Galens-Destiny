using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SavedGamesManager : MonoBehaviour
{

    //Oject with two buttons one to play the game and the other to delete the game
    public GameObject buttonsPrefab;
    // Start is called before the first frame update
    void Start()
    {
        GameData.Deserialize();
        InstantiateButtons();
    }

    void InstantiateButtons()
    {
        // populate the list to test the UI
        for (int i = 0; i < 40; i++)
        {
            SavedGame g = new() { id= i, Name = "Game "+i, Date = "01/01/2021", worldMapId = "1" };
            GameData.SavedGames.Add(g);
        }
        Debug.Log(GameData.SavedGames.Count);
        for (int i = 0; i < GameData.SavedGames.Count; i++)
        {
            GameObject go = Instantiate(buttonsPrefab, transform);
            SavedGame game = GameData.SavedGames[i];
            // write the name of the game in the button
            go.GetComponentInChildren<TextMeshProUGUI>().text = game.Name;
            // OnClick set the current game index to the index of the game
            go.GetComponentInChildren<Button>().onClick.AddListener(() => {
                GameData.CurrentGameSelectedId = game.id;
                // Load the game scene
                SceneLoader.LoadSceneAsyncWithLoadingBar("Main Game");
            });
            
        }
    }


}

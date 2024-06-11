using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SavedGamesMenu : MonoBehaviour
{

    //Oject with two buttons one to play the game and the other to delete the game
    public GameObject buttonsPrefab;
    // Start is called before the first frame update
    void Start()
    {
        GamesData.Deserialize();
        InstantiateButtons();
    }

    void InstantiateButtons()
    {
        GamesData.Deserialize();
        // populate the list to test the UI
        for (int i = 0; i < 2; i++)
        {
            SavedGame g = new() { id= i, Name = "Game "+i, Date = "01/01/2021", worldMapId = "1" };
            GamesData.SavedGames.Add(i, g);
        }
        Debug.Log(GamesData.SavedGames.Count);
        for (int i = 0; i < GamesData.SavedGames.Count; i++)
        {
            SavedGame game = GamesData.SavedGames[i];
            GameObject prefab = Instantiate(buttonsPrefab, transform);
            Button gameButton = prefab.transform.Find("Game").GetComponent<Button>();
            gameButton.GetComponentInChildren<TextMeshProUGUI>().text = game.Name;
            gameButton.onClick.AddListener(() => {
                GamesData.CurrentGameSelectedId = game.id;
                SceneLoader.LoadSceneAsyncWithLoadingBar("Main Game");
            });

            Button deleteButton = prefab.transform.Find("Delete").GetComponent<Button>();
            deleteButton.onClick.AddListener(() => {
                Debug.Log("Delete game " + game.Name);
                GamesData.SavedGames.Remove(game.id);
                Debug.Log(GamesData.SavedGames);
                GamesData.Serialize();
                RefeshButtons();
            });
            
        }
    }

    void RefeshButtons()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        InstantiateButtons();
    }


}

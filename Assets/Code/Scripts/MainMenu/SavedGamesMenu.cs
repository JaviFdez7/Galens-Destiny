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
        foreach (int key in GamesData.SavedGames.Keys)
        {
            SavedGame game = GamesData.SavedGames[key];
            GameObject prefab = Instantiate(buttonsPrefab, transform);
            Button gameButton = prefab.transform.Find("Game").GetComponent<Button>();
            gameButton.GetComponentInChildren<TextMeshProUGUI>().text = game.Name;
            gameButton.onClick.AddListener(() => {
                GamesData.CurrentGameSelectedId = game.id;
                SceneLoader.LoadSceneAsyncWithLoadingBar("Main Game");
            });

            Button deleteButton = prefab.transform.Find("Delete").GetComponent<Button>();
            deleteButton.onClick.AddListener(() => {
                GamesData.SavedGames.Remove(game.id);
                Debug.Log("Deleted game " + game.Name);
                GamesData.Serialize();
                RefreshButtons();
            });
            
        }
    }

    public void RefreshButtons()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        InstantiateButtons();
    }

    public void CreateNewGame()
    {
        SavedGame game = new SavedGame();
        GamesData.SavedGames.Add(game.id, game);
        GamesData.CurrentGameSelectedId = game.id;
        GamesData.Serialize();
        RefreshButtons();
    }

}

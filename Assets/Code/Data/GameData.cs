using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;



public static class GamesData
{
    public static int CurrentGameSelectedId;
    public static Dictionary<int,SavedGame> SavedGames = new Dictionary<int, SavedGame>();

    public static void Serialize()
    {
        JsonPersistor.SerializeData("GameData", SavedGames);
    }

    public static void Deserialize()
    {
        SavedGames = JsonPersistor.DeserializeData<Dictionary<int,SavedGame>>("GameData");
        Debug.Log(SavedGames.ToString());
        if (SavedGames == null)
        {
            SavedGames = new Dictionary<int, SavedGame>();
        }
    }

}




public class SavedGame
{
    public int id;
    public string Name;
    public string Date;
    public string worldMapId;
    public MiniGamesData MiniGamesData = new MiniGamesData();
    public ArchivementsData Archivements = new ArchivementsData();

    public SavedGame()
    {
        id = GamesData.SavedGames.Keys.Max() + 1;
    }
}


public class MiniGamesData
{
}

public class ArchivementsData
{
    public List<ArchivementData> Archivements = new List<ArchivementData>();
}

public class ArchivementData
{
    public string Name;
    public string Description;
    public bool IsUnlocked;
}

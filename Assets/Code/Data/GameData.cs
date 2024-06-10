using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;



public static class GameData
{
    public static int CurrentGameSelectedId;
    public static List<SavedGame> SavedGames = new List<SavedGame>();

    public static void Serialize()
    {
        JsonPersistor.SerializeData("GameData", SavedGames);
    }

    public static void Deserialize()
    {
        SavedGames = JsonPersistor.DeserializeData<List<SavedGame>>("GameData");
        if (SavedGames == null)
        {
            SavedGames = new List<SavedGame>();
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

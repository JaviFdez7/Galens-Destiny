using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;



public static class GameData
{
    public static List<SavedGame> SavedGames = new List<SavedGame>();


}




public class SavedGame
{
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

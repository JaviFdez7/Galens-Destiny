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
    public WorldData WorldData = new WorldData();
    public MiniGamesData MiniGamesData = new MiniGamesData();
    public ArchivementsData Archivements = new ArchivementsData();
}

public class WorldData
{
    public int Seed = 20102000;
}

public class MiniGamesData
{
}

public class ArchivementsData
{
    public Dictionary<string, ArchivementData> Archivements = new Dictionary<string, ArchivementData>();
}

public class ArchivementData
{
    public string Name;
    public string Description;
    public bool IsUnlocked;
}

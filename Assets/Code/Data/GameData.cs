using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;



public static class GamesData
{
    public static int CurrentGameSelectedId=0;
    public static SortedDictionary<int,SavedGame> SavedGames = new();

    public static void Serialize()
    {
        JsonPersistor.SerializeData("GameData", SavedGames);
    }

    public static void Deserialize()
    {
        if( JsonPersistor.CheckIfDataExists("GameData") == false)
        {
            JsonPersistor.SerializeData("GameData", SavedGames);
        }
        SavedGames = JsonPersistor.DeserializeData<SortedDictionary<int,SavedGame>>("GameData");
        Debug.Log(SavedGames.ToString());
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

        id = GenerateId();
        Name = RandomName()+" "+id;
    }

    private string RandomName(){
        //futuristic names. Invented language
        List<string> name1 = new List<string> {"Hue", "Ale", "Woz", "Yur", "Wue", "Zir", "Xur", "Tot", "Wes", "Ser", "Plen", "Osk", "Nes", "Mik", "Lur", "Kos", "Jes", "Hos", "Gos", "Fes", "Esk", "Dos", "Cos", "Bes", "Aka","Boa"};

        List<string> name2 = new List<string> {"Aklewlor", "Hoskarme", "Wozginar", "Yuranto", "Wuelmire", "Zirgir", "Xurkire", "Totemonk", "Wesmarlon", "Serseul", "Plenmire", "Oskarlon", "Nesmire", "Mikarlon", "Lurkire", "Kosmarlon", "Jesmire", "Hoskire", "Gosmarlon", "Fesmire", "Eskarlon", "Doskire", "Cosmarlon", "Besmire", "Akarlon"};

        return name1[Random.Range(0, name1.Count)] +" "+ name2[Random.Range(0, name2.Count)];
    }
    private void RefreshDate()
    {
        this.Date = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm");
    }

    private int GenerateId()
    {
        Debug.Log(GamesData.SavedGames.Keys.Count);
        Debug.Log(GamesData.CurrentGameSelectedId);
        if (GamesData.SavedGames.Keys.Count > 0)
        {
            return GamesData.SavedGames.Keys.Max() + 1;
        }
        else
        {
            return 0;
        }
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

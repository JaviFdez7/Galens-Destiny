
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public static class WorldMapManager
{
    public static string  fileName = "WorldMapsData";

    
    public static List<WorldMapData> StaticWorlds = new List<WorldMapData>();


    public static bool Serialize()
    {
        try
        {
            JsonPersistor.SerializeData(fileName, StaticWorlds);
            return true;
        }
        catch (System.Exception)
        {
            return false;
        }
        
    }
    public static void Deserialize(bool useDefaultData = false)
    {
        try
        {
            if(useDefaultData)
            {
                throw new System.Exception();
            }
            StaticWorlds = JsonPersistor.DeserializeData<List<WorldMapData>>(fileName);
            if (StaticWorlds == null)
            {
                Debug.LogError("Failed to load data from file " + fileName);
                throw new System.Exception();
            }
        }
        catch (System.Exception)
        {
            // Load default data from json file in Resources folder maps.json
            string json = Resources.Load<TextAsset>("maps").text;
            Debug.Log(json);
            StaticWorlds = JsonConvert.DeserializeObject<List<WorldMapData>>(json);
            Debug.Log(StaticWorlds.Count);


        }

    }





}


public class WorldMapData
{
    public string id;
    public string name;
    public string description;

    public int gridWidth;
    public int gridHeight;
    public int cellWidth;
    public int cellHeight;

    public List<SectorData> sectors;



}

public class SectorData {
    public int x;
    public int y;
    public string name;
    public string roomPrefabName;

    public List<DoorType> doorFrames;
    public int numberOfEnemies;
    public List<string> possibleEnemies;
    public int difficulty;

}


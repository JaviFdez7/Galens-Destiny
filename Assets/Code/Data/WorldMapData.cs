
using System.Collections.Generic;
using Newtonsoft.Json;
using Unity.Profiling.LowLevel.Unsafe;
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
    public int sectorWidth;
    public int sectorHeight;

    public List<SectorData> sectors;



}
public class Point2DInt
{
    public int x;
    public int y;

    public Point2DInt(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }
        Point2DInt p = (Point2DInt)obj;
        return (x == p.x) && (y == p.y);
    }
    // public override string ToString()
    // {
    //     return "{ " +'\u0022' + "x" + '\u0022' + ": " + x + ", " + '\u0022' + "y" + '\u0022' + ": " + y + " }";
    // }
        public override int GetHashCode()
    {
        return x.GetHashCode() ^ x.GetHashCode();
    }
}

public class SectorData {
    public Point2DInt origin;
    public string name;
    public string roomPrefabName;

    public List<DoorData> doors;
    public int key;
    public int numberOfEnemies;
    public List<string> possibleEnemies;
    public int difficulty;

}

public class DoorData{
    public int key;
    public DoorDirection direction;
}


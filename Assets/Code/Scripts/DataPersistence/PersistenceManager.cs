using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class PersistenceManager
{
    public static void SerializeData(string fileName, object data)
    {   
        try
        {
        // Save GameData to Json file
        string json = JsonConvert.SerializeObject(data, Formatting.Indented);
        Debug.Log("saved: " + json);
        //Different systems use different slashes in their paths, so it's better to use Path.Combine
        File.WriteAllText(Path.Combine(Application.persistentDataPath, fileName + ".json"), json);
        }
        catch (System.Exception)
        {
            Debug.LogError("Failed to save data to file");
        }
    }
    public static T DeserializeData<T>(string fileName)
    {
        try
        {
            // Load GameData from Json file
            string json = File.ReadAllText(Application.persistentDataPath + "/" + fileName + ".json");
            T data = JsonUtility.FromJson<T>(json);
            Debug.Log("loaded: " + json);
            return data;
            
        }
        catch (System.Exception)
        {
            Debug.LogError("Failed to load data from file"+fileName);
            return default;
        }
    }
}
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public static class PersistorManager
{
    public static event System.Action SerializeDataEvent;
    public static event System.Action DeserializeDataEvent;
    public static void SerializeSubscribersData()
    {
        if (SerializeDataEvent != null)
        {
            SerializeDataEvent();
        }
    }
    public static void DeserializeSubscribersData()
    {
        if (DeserializeDataEvent != null)
        {
            DeserializeDataEvent();
        }
    }
}
public class JsonPersistor
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
            Debug.LogError("Failed to save data to file " + fileName);
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
            Debug.LogError("Failed to load data from file " + fileName);
            return default;
        }
    }
}


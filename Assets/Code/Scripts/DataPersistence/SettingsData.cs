using UnityEditor;

public static class SettingsManager
{
    public static int LanguageIndex = 0;
    public static bool AutoSave = true;


    public static void Serialize()
    {
        SettingsData settingsData = new SettingsData(LanguageIndex, AutoSave);
        JsonPersistor.SerializeData("Settings", settingsData);
    }
    public static void Deserialize()
    {
        SettingsData data = JsonPersistor.DeserializeData<SettingsData>("Settings");
        if (data != null)
        {
           LanguageIndex = data.LanguageIndex;
            AutoSave = data.AutoSave;
        }
    }

}
public class SettingsData
{
    public int LanguageIndex;
    public bool AutoSave;

    public SettingsData(int languageIndex, bool autoSave)
    {
        LanguageIndex = languageIndex;
        AutoSave = autoSave;
    }
}

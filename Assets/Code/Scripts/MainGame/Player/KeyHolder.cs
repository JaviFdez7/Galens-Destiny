using System.Collections;
using System.Collections.Generic;
using UnityEditor.Localization.Plugins.XLIFF.V12;
using UnityEngine;
using UnityEngine.UI;


public class KeyHolder : MonoBehaviour
{
    // Start is called before the first frame update
    public List<int> keys = new();
    //Reference to the gridlayout gameobject
    public GameObject gridLayout;
    public GameObject keyImagePrefab;
    public static List<Color> keyColors = new List<Color>
    {
        Color.red,
        Color.blue,
        Color.green,
        Color.yellow,
        Color.magenta,
        Color.cyan,
        Color.black,
        Color.white
    };
    public static Color GetKeyColor(int key)
    {
        if (key < 0) return Color.black;
        Color selectedColor = keyColors[key % keyColors.Count];
        return IncreaseBrightness(selectedColor, 0.7f);
    }
    public static Color IncreaseBrightness(Color color, float amount)
    {
        return new Color(Mathf.Clamp01(color.r + amount), Mathf.Clamp01(color.g + amount), Mathf.Clamp01(color.b + amount));
    }

    public void AddKey(int key)
    {

        keys.Add(key);
        // Instantiate the keyImage prefab
        GameObject keyImage = Instantiate(keyImagePrefab);
        // Set the parent to the gridLayoutGroup to automatically position it
        keyImage.transform.SetParent(gridLayout.transform, false);
        // Set the color of the keyImage
        keyImage.GetComponent<Image>().color = GetKeyColor(key);

    }
    public void RemoveKey(int key)
    {
        keys.Remove(key);
        Destroy(gridLayout.transform.GetChild(key).gameObject);
    }

    public bool HasKey(int key)
    {
        if (key == -1) return true;
        Debug.Log("Checking if player has key: " + key + " keys: " + string.Join(", ", keys));
        return keys.Contains(key);
    }
}

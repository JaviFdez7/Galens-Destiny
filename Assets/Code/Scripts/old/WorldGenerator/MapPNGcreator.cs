using UnityEngine;
using System.Collections.Generic;


#if UNITY_EDITOR
using UnityEditor;

public class CreateMapTexture : MonoBehaviour
{
    [MenuItem("Tools/Create Map Texture")]
    static void CreateMapTexturef()
    {
        // Create a new texture
        int sizeOfTexture = 1000;
        Texture2D texture = new(sizeOfTexture, sizeOfTexture, TextureFormat.RGBA32, false)
        {
            filterMode = FilterMode.Point,
            wrapMode = TextureWrapMode.Clamp,
            anisoLevel = 1
        };

        // Fill the texture with linear colors
        int PaletteSize = 21;
        Color32[] colors = new Color32[sizeOfTexture * sizeOfTexture];
        for (int y = 0; y < sizeOfTexture; y++)
        {
            for (int x = 0; x < sizeOfTexture; x++)
            {
                //random color for each pixel b always 0, a always 255 unless r and g = 0
                Color32 color = new((byte)Random.Range(1, PaletteSize), (byte)Random.Range(1, PaletteSize), 0, 255);
                colors[y * sizeOfTexture + x] = color;
            }
        }

        texture.SetPixels32(colors);
        texture.Apply();

        // Save the texture as an asset
        string path = "Assets/Code/Scripts/WorldGenerator/map.png";
        byte[] bytes = texture.EncodeToPNG();
        System.IO.File.WriteAllBytes(path, bytes);
        AssetDatabase.ImportAsset(path);
        AssetDatabase.Refresh();
    }
}
#endif

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* WorldGen
    This class is responsible for generating the world. It reads the data from a json file
    and instantiates the objects in the scene. It has an array of rooms prefabs that will be
    instantiated in the scene. From the json file, it reads the info for each sector and instantiates
    the corresponding room prefab.
 */
public class WorldGen : MonoBehaviour
{

    public int selectedMapIndex = 0;
    void Start()
    {

        WorldMapManager.Deserialize(true);
        GenerateWorld(WorldMapManager.StaticWorlds[selectedMapIndex]);
        
    }

    // Update is called once per frame
    void Update()
    {
        // if 7 is pressed, save the worlds with name "WorldMapData"
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            WorldMapManager.Serialize();
            Debug.Log("Saved");
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            WorldMapManager.Deserialize();
            GenerateWorld(WorldMapManager.StaticWorlds[selectedMapIndex]);
            Debug.Log("Loaded");
        }
    }

    // Generate the world
    public void GenerateWorld(WorldMapData worldMapData)
    {
        foreach (SectorData sector in worldMapData.sectors)
        {
            Vector2 position = new(sector.x * worldMapData.cellWidth, sector.y * worldMapData.cellHeight);
            GameObject room = Instantiate(Resources.Load<GameObject>("Prefabs/Rooms/" + sector.roomPrefabName), position, Quaternion.identity);
            room.name = sector.name;
        }
    }
    

}

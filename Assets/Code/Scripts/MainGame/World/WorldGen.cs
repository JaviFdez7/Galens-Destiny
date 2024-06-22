using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

/* WorldGen
    This class is responsible for generating the world. It reads the data from a json file
    and instantiates the objects in the scene. It has an array of rooms prefabs that will be
    instantiated in the scene. From the json file, it reads the info for each sector and instantiates
    the corresponding room prefab.
 */
public class WorldGen : MonoBehaviour
{
    public static WorldGen instance;
    public int selectedMapIndex = 0;
    void Start()
    {

        Test();
        WorldMapManager.Deserialize(true);
        GenerateWorld(WorldMapManager.StaticWorlds[selectedMapIndex]);
    }

    public void Test(){
        var result = "";
        Dictionary<int, Point2DInt> testDict = new Dictionary<int, Point2DInt>();
        // Point2DInt testPoint = new();
        // testPoint.x = 1;
        // testPoint.y = 2;
        Point2DInt testPoint = new(1, 2);
        string x = JsonConvert.SerializeObject(testPoint);
        Debug.Log("serialize: "+x);
        testDict.Add(1, testPoint);
        result = JsonConvert.SerializeObject(testDict);
        Debug.Log("serialize: "+result);
        Dictionary<int, Point2DInt> testDict2 = JsonConvert.DeserializeObject<Dictionary<int, Point2DInt>>(result);
        Debug.Log("deserialize: "+testDict2[1]);
        Debug.Log("suuu"+testDict2[1]);
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
            Vector2 position = new(sector.origin.x * worldMapData.sectorWidth, sector.origin.y * worldMapData.sectorHeight);
            GameObject room = Instantiate(Resources.Load<GameObject>("Prefabs/Rooms/" + sector.roomPrefabName), position, Quaternion.identity);
            if (room.TryGetComponent<RoomDoorFrames>(out RoomDoorFrames roomDoorFrames))
            {
                foreach (DoorData door in sector.doors)
                {
                    roomDoorFrames.RemoveWallAndSetDoor(door);
                }
            };
            EnemySpawner spawner = room.GetComponentInChildren<EnemySpawner>();
            if (spawner != null)
            {
                spawner.possibleEnemies = sector.possibleEnemies;
                spawner.numberOfEnemy = sector.numberOfEnemies;
                spawner.possibleEnemies = sector.possibleEnemies;
                spawner.LoadEnemiesFromResources();
            }
            if (sector.key != -1 && sector.key != 0)            {
                GameObject key = Instantiate(Resources.Load<GameObject>("Prefabs/Items/Key"),room.transform);
                key.transform.localPosition = new Vector2(7,0);
                PickKey pickKey = key.GetComponent<PickKey>();
                if (pickKey != null)
                    pickKey.id = sector.key;
                pickKey.Start();
            }



        }
    }

    public void GenerateSectors()
    {
        // Generate sectors
    }

    public void GenerateDoors()
    {
        // Generate doors
    }

    public void GetNeighbours(SectorData sectorData)
    {
        // Get neighbours
    }
    

}



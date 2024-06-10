using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Tilemap))]
public class TilemapGenerator : MonoBehaviour
{
    // public TileBase tile; // The tile you want to use
    public int width = 16; // Width of the tilemap
    public int height = 16; // Height of the tilemap
    public int depth = 5; // Depth of the tilemap
    private int tileCount = 0; // Counter for the number of tiles created
    public TileBase selectedTile=null; // The tile you want to use
    void Update()
    {
        // Check for Space key press to trigger tilemap generation
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Copying Ground Tilemap");
            CopyGroundTilemap();
        }else if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("Generating Land Tilemap");
            GenerateLandTilemap();
        }else if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("Copying Land Tilemap to different Z and XY");
            CopyGroundTilemapToDifferentZandXY();
        }
    }

    public void CopyGroundTilemap()
    {
        Tilemap tilemap = GetComponent<Tilemap>();


        // Reset tile count
        tileCount = 0;

        for (int z = 0; z < depth; z++)
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    TileBase tile = tilemap.GetTile(new Vector3Int(x, y, 0));
                    Vector3Int tilePosition = new Vector3Int(x-z, y-z, z);
                    tilemap.SetTile(tilePosition, tile);
                    if( tile !=null )tileCount++;
                }
            }
        }

        // Log the number of tiles created
        Debug.Log("Tilemap generation complete. Total tiles created: " + tileCount);
    }
    public void CopyGroundTilemapToDifferentZandXY()
    {
        Tilemap tilemap = GetComponent<Tilemap>();


        // Reset tile count
        tileCount = 0;

        for (int z = 0; z < depth; z++)
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    TileBase tile = tilemap.GetTile(new Vector3Int(x, y, 0));
                    Vector3Int tilePosition = new Vector3Int(x-z*width, y-z*height, z);
                    tilemap.SetTile(tilePosition, tile);
                    if( tile !=null )tileCount++;
                }
            }
        }

        // Log the number of tiles created
        Debug.Log("Tilemap generation complete. Total tiles created: " + tileCount);
    }


    public void GenerateLandTilemap()
    {
        Tilemap tilemap = GetComponent<Tilemap>();

        // Reset tile count
        tileCount = 0;


            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Vector3Int tilePosition = new Vector3Int(x, y, 0);
                    tilemap.SetTile(tilePosition, selectedTile);
                    if( selectedTile !=null )tileCount++;
                }
            }

        // Log the number of tiles created
        Debug.Log("Tilemap generation complete. Total tiles created: " + tileCount);
    }
}
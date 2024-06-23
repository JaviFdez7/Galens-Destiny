using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    // Tile prefab to spawn
    public GameObject tilePrefab;

    // Number of tiles along x and y axes
    public int numTilesX = 16*8;
    public int numTilesY = 16*8;

    // Spacing between tiles
    public float tileSpacing = 1f;

    void Start()
    {
        SpawnTiles();
    }

    void SpawnTiles()
    {
        // Calculate the starting position for spawning
        Vector3 startPos = transform.position - new Vector3(numTilesX * tileSpacing * 0.5f, 0f, numTilesY * tileSpacing * 0.5f);

        // Loop through each row and column to spawn tiles
        for (int y = 0; y < numTilesY; y++)
        {
            for (int x = 0; x < numTilesX; x++)
            {
                // Calculate the position for this tile
                Vector3 tilePos = startPos + new Vector3(x * tileSpacing, 0f, y * tileSpacing);

                // Instantiate the tile prefab at the calculated position
                GameObject tile = Instantiate(tilePrefab, tilePos, Quaternion.identity);

                // Optional: Set the parent of the instantiated tile to keep the hierarchy clean
                tile.transform.SetParent(transform);
            }
        }
    }
}
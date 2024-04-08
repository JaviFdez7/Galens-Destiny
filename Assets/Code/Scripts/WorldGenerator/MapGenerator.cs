using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapGenerator : MonoBehaviour
{

    [SerializeField] private Vector3Int chunkSize = WorldGenerator.chunkSize;
    [SerializeField] private int renderDistance = WorldGenerator.renderDistance;
    [SerializeField] private int seed = WorldGenerator.seed;
    [SerializeField] private int scale = WorldGenerator.scale;
    [SerializeField] private int octaves = WorldGenerator.octaves;
    [SerializeField] private float lacunarity = WorldGenerator.lacunarity;
    [SerializeField] private float persistence = WorldGenerator.persistence;
    [SerializeField] private Tilemap tilemap = WorldGenerator.tilemap;
    [SerializeField] private Tile tile = WorldGenerator.tile;

    Vector2Int[,] loadedChunks = new Vector2Int[0, 0];
    Vector2Int lastVisitedChunk = new Vector2Int(-5000, -5000);
    Vector2Int currentChunk = new Vector2Int(0, 0);
    void Start()
    {
        WorldGenerator.SetGenerator(chunkSize, renderDistance, seed, scale, octaves, lacunarity, persistence, tilemap, tile);
        WorldGenerator.UpdateActiveChunks(GetCurrentChunk(),true);
    }
    //if space pressed initialize world
    void Update()
    {

            currentChunk = GetCurrentChunk();
        if (lastVisitedChunk != currentChunk)
        {
            WorldGenerator.UpdateActiveChunks(currentChunk,true);
            lastVisitedChunk = currentChunk;
        }

    }




    public Vector2Int GetCurrentChunk(){
        Vector3Int tileCurrentPosition = tilemap.WorldToCell(transform.position);
        Vector2Int currentChunk = new(chunkSize.x *( tileCurrentPosition.x / WorldGenerator.chunkSize.x), chunkSize.y *(tileCurrentPosition.y / WorldGenerator.chunkSize.y));
        Debug.Log(currentChunk);
        return currentChunk;
    }
}

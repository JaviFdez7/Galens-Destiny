using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public static class WorldGenerator
{
    //World parameters
    public static Vector3Int chunkSize= new(16, 16, 128);
    public static int renderDistance = 4;
    //Noise parameters
    public static int mapSize = 800000000; //800km
    public static int seed = 123123;
    public static int scale = 5;

    //Unity objects
    public static Tilemap tilemap;
    public static Tile tile;
    public static int octaves;
    public static float lacunarity;
    public static float persistence;

    //Setter for the generator
    public static void SetGenerator(Vector3Int chunkSize, int renderDistance, int seed, int scale,int octaves,float lacunarity,float persistence, Tilemap tilemap, Tile tile)
    {
        WorldGenerator.chunkSize = chunkSize;
        WorldGenerator.renderDistance = renderDistance;
        WorldGenerator.seed = seed;
        WorldGenerator.scale = scale;
        WorldGenerator.tilemap = tilemap;
        WorldGenerator.tile = tile;
        WorldGenerator.octaves = octaves;
        WorldGenerator.lacunarity = lacunarity;
        WorldGenerator.persistence = persistence;
    }
    private static readonly List<Vector2Int> loadedChunks = new();

   public static void UpdateActiveChunks(Vector2Int currentChunkOriginTile, bool unloadPerimeter = false)
{
    // Generate chunks within render distance
    for (int i = -renderDistance-1; i <= renderDistance+1; i++)
    {
        for (int j = -renderDistance-1; j <= renderDistance+1; j++)
        {
            Vector2Int tilemapCoord = new(currentChunkOriginTile.x + i * chunkSize.x, currentChunkOriginTile.y + j * chunkSize.y);
            // if (unloadPerimeter && (Mathf.Abs(i)+1 == renderDistance +1 || Mathf.Abs(j)+1 == renderDistance+1))
            // {
            //     DestroyChunk(tilemapCoord);
            //     continue;
            // }
            GenerateChunk(tilemapCoord);
        }
    }

}


    private static void DestroyChunk(Vector2Int chunkOriginTile)
    {
        if (!loadedChunks.Contains(chunkOriginTile)) return;
        for (int x = chunkOriginTile.x; x < chunkOriginTile.x + chunkSize.x; x++)
        {
            for (int y = chunkOriginTile.y; y < chunkOriginTile.y + chunkSize.y; y++)
            {
                for (int z = 0; z < chunkSize.z; z++)
                {
                    Vector3Int tilePosition = new(x, y, z);
                    tilemap.SetTile(tilePosition, null);
                }
            }
        }
        loadedChunks.Remove(chunkOriginTile);
    }

    public static void InitializeWorld(Vector2Int tilemapCoord)
    {
        // Generate chunks at render distance
        UpdateActiveChunks(tilemapCoord,false);
    }
    static void GenerateChunk(Vector2Int chunkOriginTile)
    {
        if (loadedChunks.Contains(chunkOriginTile)) return;
        for (int x = chunkOriginTile.x; x < chunkOriginTile.x + chunkSize.x; x++)
        {
            for (int y = chunkOriginTile.y; y < chunkOriginTile.y + chunkSize.y; y++)
            {
                double zNoise = 1;
                // double zNoise = 10*GeneratePerlinNoise(x,y,scale,octaves,lacunarity,persistence);
                for (int z = 0; z < chunkSize.z; z++)
                {
                    Vector3Int tilePosition = new(x, y, z + (int)zNoise);
                    tilemap.SetTile(tilePosition, tile);
                }
            }
        }
        loadedChunks.Add(chunkOriginTile);
    }

     public static float GeneratePerlinNoise(float x, float y, float scale, int octaves, float lacunarity, float persistence)
    {
        float noiseValue = 0;
        float amplitude = 1;
        float frequency = 1;

        // Loop through octaves
        for (int i = 0; i < octaves; i++)
        {
            float xCoord = x * frequency / scale;
            float yCoord = y * frequency / scale;

            // Generate Perlin noise value for current octave
            noiseValue += Mathf.PerlinNoise(xCoord, yCoord) * amplitude;

            // Update amplitude and frequency for the next octave
            amplitude *= persistence;
            frequency *= lacunarity;
        }

        return noiseValue;
    }



}
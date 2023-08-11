using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "New Movement Speed Tile", menuName = "Tiles/Movement Speed Tile")]
public class MovementSpeedTile : Tile
{
    public float movementSpeedMultiplier = 1f;
}
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "NewRuleTile" , menuName = "RuleTiles/NewRuleTile") ]
public class HexagonRuleTile : RuleTile
{
    public bool Walkable;
    public Color color;
    public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
    {
        base.GetTileData(position, tilemap, ref tileData);
        tileData.color = color;
        tileData.flags = TileFlags.LockColor;
    }
}

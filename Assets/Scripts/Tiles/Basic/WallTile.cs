using UnityEngine;
namespace GridManagement.Tiles
{
    public class WallTile : Tile
    {
        public override bool IsWalkable() => false;
    }
}


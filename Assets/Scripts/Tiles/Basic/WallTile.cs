using UnityEngine;
namespace Game.GridManagement.Tiles
{
    public class WallTile : Tile
    {
        public override bool IsWalkable() => false;
    }
}


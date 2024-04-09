
using System.Net.Http.Headers;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
namespace GridManagement.Tiles
{
    public class WallTile : Tile
    {
        [SerializeField] private TileType _tileType;
        public override TileType GetTileType() => _tileType;
        public override bool IsWalkable() => false;
    }
}


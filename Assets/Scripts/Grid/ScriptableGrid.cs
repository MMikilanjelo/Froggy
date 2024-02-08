using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridManagment.Tiles;
namespace GridManagment
{
    [CreateAssetMenu(fileName = "New Scriptable Hex Grid")]
    public class ScriptableGrid : ScriptableObject
    {   
        private TileFactory _tileFactory;
        [SerializeField,Range(1,50)] private int _gridWidth = 16;
        [SerializeField,Range(1,50)] private int _gridDepth = 9;
        public void Initialize(TileFactory tileFactory)
        {
            _tileFactory = tileFactory;
        }
        public  Dictionary<Vector2, Tile> GenerateGrid() {
            var tiles = new Dictionary<Vector2, Tile>();
            var grid = new GameObject {
                name = "Grid"
            };
            for (var r = 0; r < _gridDepth ; r++) {
                var rOffset = r >> 1;
                for (var q = -rOffset; q < _gridWidth - rOffset; q++) {
                    var tile = _tileFactory.InstantiateTile(TileType.Wall , grid.transform , q ,r);
                    tiles.Add(tile.Coords.Pos,tile);
                }
            }

            return tiles;
        }
    
    }
}


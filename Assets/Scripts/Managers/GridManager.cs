using System.Collections.Generic;
using UnityEngine;
using Game.Utilities.Singletons;
using Game.GridManagement.Tiles;
namespace Game.GridManagement
{   
    public class GridManager : Singleton<GridManager>
    {
        [SerializeField] private TileFactory _tileFactory;
        [SerializeField] private TileCollection _tileCollection;
        [SerializeField] private ScriptableGrid _scriptableGrid;
        public  IReadOnlyDictionary<Vector2 , Tile> _tilesInGrid;
        protected override  void Awake(){
            _tileFactory.Initialize(_tileCollection);
            _scriptableGrid.Initialize(_tileFactory);
        }
        public void GenerateGrid()
        {
            _tilesInGrid = _scriptableGrid.GenerateGrid();
            foreach (var tile in _tilesInGrid.Values) {
                tile.CacheNeighbors();
            }
                
        }
        public Tile GetTileAtPosition(Vector2 position){
            if(_tilesInGrid.TryGetValue(position, out var tile)) {
                return tile;
            }
            return null;
        }
    }
}

                



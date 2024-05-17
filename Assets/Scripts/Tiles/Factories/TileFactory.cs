using System.Collections.Generic;
using UnityEngine;


namespace GridManagement.Tiles
{
    [CreateAssetMenu(fileName ="TileFactory" , menuName = "Factory/TileFactory")]
    public class TileFactory : ScriptableObject
    {
        [SerializeField] private Tile _defaultTile;
        public readonly Dictionary<TileType , Tile> _tiles = new Dictionary<TileType, Tile>();
        public Tile InstantiateTile(TileType tileType , Transform parent , int q , int r) {
            Tile tileInstance = Instantiate(GetPrefab(tileType) , parent);
            tileInstance.Initialize(new HexCoords(q ,r));
            return tileInstance;
        }
        private Tile GetPrefab(TileType tileType) {
            if(_tiles.ContainsKey(tileType)){
                return _tiles[tileType];
            }
            return _defaultTile;
        }
        
        public void Initialize(TileCollection tileCollection){
            foreach(var tile in tileCollection.AllTilesData){
                _tiles.Add(tile.Type , tile.Prefab);
            }
        }
    }
}


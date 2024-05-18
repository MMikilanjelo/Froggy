using System.Collections.Generic;
using UnityEngine;


namespace Game.GridManagement.Tiles
{
    [CreateAssetMenu(fileName ="TileFactory" , menuName = "Factory/TileFactory")]
    public class TileFactory : ScriptableObject
    {
        [SerializeField] private Tile defaultTile_;
        public readonly Dictionary<TileType , Tile> tiles_ = new Dictionary<TileType, Tile>();
        public Tile InstantiateTile(TileType tileType , Transform parent , int q , int r) {
            Tile tileInstance = Instantiate(GetPrefab(tileType) , parent);
            tileInstance.Initialize(new HexCoords(q ,r));
            return tileInstance;
        }
        private Tile GetPrefab(TileType tileType) {
            if(tiles_.ContainsKey(tileType)){
                return tiles_[tileType];
            }
            return defaultTile_;
        }
        
        public void Initialize(TileCollection tileCollection){
            foreach(var tile in tileCollection.AllTilesData){
                tiles_.Add(tile.Type , tile.Prefab);
            }
        }
    }
}


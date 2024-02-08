using System.Collections.Generic;
using UnityEngine;


namespace GridManagment.Tiles
{
    [CreateAssetMenu(fileName ="TileFactory" , menuName = "Factory/TileFactory")]
    public class TileFactory : ScriptableObject
    {
        [SerializeField] private Tile _defaultTile;
        public readonly Dictionary<TileType , Tile> _tyles = new Dictionary<TileType, Tile>();
        public Tile InstantiateTile(TileType tileType , Transform parent , int q , int r) {
            Tile tileInstance = Instantiate(GetPrefab(tileType) , parent);
            tileInstance.Initialize(new HexCoords(q ,r));
            return tileInstance;
        }
        private Tile GetPrefab(TileType tileType) {
            if(_tyles.ContainsKey(tileType)){
                return _tyles[tileType];
            }
            return _defaultTile;
        }
        
        public void Initialize(TileCollection tileCollection){
            foreach(var tyle in tileCollection.AllTilesData){
                _tyles.Add(tyle.Type , tyle.Prefab);
            }
        }
    }
}


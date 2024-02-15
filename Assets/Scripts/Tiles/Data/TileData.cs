using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GridManagement.Tiles
{
    [CreateAssetMenu(fileName ="TileData" ,menuName = "Tiles/TileData")]
    public class TileData : ScriptableObject
    {
        [SerializeField] public Tile Prefab; 
        public TileType Type => Prefab.GetTileType();
    }
}


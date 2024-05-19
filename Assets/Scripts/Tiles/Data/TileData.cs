using UnityEngine;

namespace Game.GridManagement.Tiles
{
    [CreateAssetMenu(fileName ="TileData" ,menuName = "Tiles/TileData")]
    public class TileData : ScriptableObject
    {
        [SerializeField] public Tile Prefab; 
        [SerializeField] public TileType Type;
    }
}


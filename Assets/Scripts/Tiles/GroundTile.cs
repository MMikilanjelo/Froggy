
using UnityEngine;
using UnityEngine.EventSystems;

namespace GridManagment.Tiles
{
    public class GroundTile : Tile , ISelectable
    {
        [SerializeField] private TileType tileType;
        [SerializeField] private GameObject _highlight;
        public override TileType GetTileType() => tileType;

        public override bool IsWalkable() => true;
        public void Select(){
            
            _highlight.SetActive(true);
        }
        public void UnSelect(){
            _highlight.SetActive(false);
        }
    }
}


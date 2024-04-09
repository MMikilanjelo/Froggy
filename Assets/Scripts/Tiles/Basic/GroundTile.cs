
using Entities;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GridManagement.Tiles
{
    public class GroundTile : Tile , ISelectable , ITileVisitable
    {
        [SerializeField] private TileType _tileType;
        [SerializeField] private GameObject _highlight;
        public override TileType GetTileType() => _tileType;
        public override bool IsWalkable() => OccupiedEntity == null;
        public void Accept(ITileVisitor tileVisitor) => tileVisitor.Visit(this);
        public void Select() => _highlight.SetActive(true);
        public void UnSelect() => _highlight.SetActive(false);
    }
}


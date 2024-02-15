using GridManagement.Tiles;
using UnityEngine;

namespace Entity
{
    public abstract class Hero : MonoBehaviour, IEntity
    {
        protected Tile _occupiedTile;
        public Tile OccupiedTile => _occupiedTile;
        public void SetOccupiedTile(Tile tile) => _occupiedTile = tile;
        
    }
}   


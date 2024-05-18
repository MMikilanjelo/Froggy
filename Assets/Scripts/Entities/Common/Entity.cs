using Game.GridManagement.Tiles;
using UnityEngine;

namespace Game.Entities
{   
    public abstract class Entity : MonoBehaviour
    {
        public Tile OccupiedTile{get;protected set;}
        public void SetOccupiedTile(Tile tile){
            OccupiedTile = tile;
        }
    }
}


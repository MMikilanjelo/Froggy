using GridManagement.Tiles;
using UnityEngine;

namespace Entities
{   
    public abstract class Entity : MonoBehaviour
    {
        public Tile OccupiedTile{get;protected set;}
        public void SetOccupiedTile(Tile tile){
            OccupiedTile = tile;
        }
    }
}


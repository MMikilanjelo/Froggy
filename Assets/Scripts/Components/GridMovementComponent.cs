using Entity.Stats;
using GridManagment.Tiles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Entity.Components
{
    public class GridMovementComponent : MonoBehaviour
    {
          
        public void Move(IEntity entity ,  Tile targetTile)
        {
            List<Tile> path = FindPath(entity.OccupiedTile, targetTile);
        }

        private List<Tile> FindPath(Tile current, Tile target)
        {
            return PathFinding.FindPath(current, target);
        }
    }
}



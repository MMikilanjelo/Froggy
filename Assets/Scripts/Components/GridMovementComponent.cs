using GridManagement.Tiles;
using Managers;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace Entities.Components
{
    public class GridMovementComponent 
    {
        private Entity _entity;
        private Coroutine _moveCoroutine;
        private float _moveSpeed = 10.0f;
        public GridMovementComponent(Entity entity){
            _entity = entity;
        }
        public void Move(Tile targetTile)
        {
            if(targetTile.OccupiedEntity != null){
                return;
            }
            SelectionManager.Instance.UnHightLightTiles();
            List<Tile> path = FindPath(_entity.OccupiedTile, targetTile);

            if(path != null) {
                _entity.isTakingAction = true;
                _entity.OccupiedTile.SetOccupiedEntity(null);
                _entity.SetOccupiedTile(null);  
                foreach(var tile in path){
                    SelectionManager.Instance.SelectTile(tile);
                }
                if(_moveCoroutine != null){
                    _entity.StopCoroutine(_moveCoroutine);
                }
                _moveCoroutine = _entity.StartCoroutine(MoveAlongPath(path));
                SelectionManager.Instance.HightLightTiles();
            }
        }   
        private IEnumerator MoveAlongPath(List<Tile> path){
            int startIndex = 0;
            while (startIndex < path.Count)
            {
                Vector3 targetPosition = path[startIndex].Coords.Pos;
                while (_entity.transform.position != targetPosition)
                {
                    _entity.transform.position = Vector3.MoveTowards(_entity.transform.position, targetPosition, _moveSpeed * Time.deltaTime);
                    yield return null;
                }
                startIndex++;
            }
            _entity.SetOccupiedTile(path.Last());
            _entity.OccupiedTile.SetOccupiedEntity(_entity);
            _entity.isTakingAction = false;
        }

        private List<Tile> FindPath(Tile current, Tile target)
        {
            return PathFinding.FindPath(current, target);

        }
    }
}



using GridManagement.Tiles;
using Managers;
using System;
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
        public event Action MovementFinished;
        public GridMovementComponent(Entity entity) {
            _entity = entity;
        }
        private void UpdateEntityTiles(){}
        public void Move(Tile targetTile) {
            if(targetTile.OccupiedEntity != null || targetTile == null || _entity.OccupiedTile == null){
                return;
            }
            // EventManager.TriggerEvent(EventTypes.GlobalEvents.GridGenerated);
            // EventManager.TriggerEvent(EventTypes.GlobalEvents.LevelStarted, 10);
            SelectionManager.Instance.UnHightLightTiles();
            List<Tile> path = FindPath(_entity.OccupiedTile, targetTile);


            if(path != null) {
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
            else {
                MovementFinished?.Invoke();
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
            MovementFinished?.Invoke();
        }

        private List<Tile> FindPath(Tile current, Tile target) {
            return PathFinding.FindPath(current, target);
        }
    }
}



using Game.GridManagement.Tiles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace Game.Entities.Components
{
	public class GridMovementComponent
	{
		private Entity entity_;
		private float moveSpeed_ = 10.0f;
		private Coroutine moveCoroutine_;
		public event Action MovementFinished;
		public event Action MovementStarted;
		public GridMovementComponent(Entity entity)
		{
			entity_ = entity;
		}
		private void UpdateEntityAndTileInfo(Tile tile)
		{
			entity_.OccupiedTile.SetOccupiedEntity(null);
			entity_.SetOccupiedTile(tile);
			entity_.OccupiedTile.SetOccupiedEntity(entity_);
		}
		public void Move(Tile targetTile)
		{
			if (targetTile == null || !targetTile.IsWalkable())
			{
				return;
			}
			List<Tile> path = FindPath(entity_.OccupiedTile, targetTile);

			if (path != null)
			{
				MovementStarted?.Invoke();
				UpdateEntityAndTileInfo(path.Last());
				if (moveCoroutine_ != null)
				{
					entity_.StopCoroutine(moveCoroutine_);
				}
				moveCoroutine_ = entity_.StartCoroutine(MoveAlongPath(path));
			}
			else
			{
				MovementFinished?.Invoke();
			}
		}
		private IEnumerator MoveAlongPath(List<Tile> path)
		{
			int startIndex = 0;
			while (startIndex < path.Count)
			{
				Vector3 targetPosition = path[startIndex].Coords.Pos;
				while (entity_.transform.position != targetPosition)
				{
					entity_.transform.position = Vector3.MoveTowards(entity_.transform.position, targetPosition, moveSpeed_ * Time.deltaTime);
					yield return null;
				}
				startIndex++;
			}

			MovementFinished?.Invoke();
		}
		private List<Tile> FindPath(Tile current, Tile target)
		{
			return PathFinding.FindPath(current, target);
		}
	}
}



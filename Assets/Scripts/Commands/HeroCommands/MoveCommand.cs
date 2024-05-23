using Game.Entities.Components;
using Game.GridManagement.Tiles;
using Game.Managers;
using UnityEngine;
namespace Game.Entities.Commands {
	public class MoveCommand : HeroCommand {
		private GridMovementComponent gridMovementComponent_;
		public MoveCommand(Entity entity) : base(entity) {
			gridMovementComponent_ = new GridMovementComponent(entity_);

			gridMovementComponent_.MovementFinished += OnMovementFinished;
			gridMovementComponent_.MovementStarted += OnMovementStarted;
		}

		public override void Execute() {
			SelectionManager.Instance.RegisterTileSelectionCallback(Move);
		}
		public override void Cancel() {
			Debug.Log("canceled a move command");
			SelectionManager.Instance.DeregisterTileSelectionCallback(Move);
		}
		private void Move(Tile tile) {
			if (entity_ != null && tile != null) {
				gridMovementComponent_.Move(tile);
			}
		}
		private void OnMovementFinished() {
			isExecuting_ = false;
			SelectionManager.Instance.DeregisterTileSelectionCallback(Move);
		}
		private void OnMovementStarted() {
			isExecuting_ = true;
		}
	}
}

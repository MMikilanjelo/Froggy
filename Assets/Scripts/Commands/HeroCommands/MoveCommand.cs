using Entities.Components;
using Game.Managers;
namespace Game.Entities.Commands {
	public class MoveCommand : HeroCommand {
		private GridMovementComponent gridMovementComponent_;
		public MoveCommand(Entity entity) : base(entity) {
			gridMovementComponent_ = new GridMovementComponent(hero);

			gridMovementComponent_.MovementFinished += OnMovementFinished;
			gridMovementComponent_.MovementStarted += OnMovementStarted;
		}

		public override void Execute() {
			if (hero != null && SelectionManager.Instance.SelectedTile != null) {
				gridMovementComponent_.Move(SelectionManager.Instance.SelectedTile);
			}
		}
		private void OnMovementFinished() {
			isExecuting_ = false;
		}
		private void OnMovementStarted() {
			isExecuting_ = true;
		}
	}
}

using Entities.Components;
using Managers;
namespace Entities.Commands
{
    public class MoveCommand : HeroCommand
    {
        private GridMovementComponent _gridMovementComponent;
        public MoveCommand(Entity entity) : base(entity){
            _gridMovementComponent = new GridMovementComponent(hero);
            
            _gridMovementComponent.MovementFinished += OnMovementFinished;
            _gridMovementComponent.MovementStarted += OnMovementStarted;
        }

        public override void Execute()
        {
            if (hero != null && PlayerSelectionManager.Instance.SelectedTile != null){
                _gridMovementComponent.Move(PlayerSelectionManager.Instance.SelectedTile);
            }
        }
        private void OnMovementFinished(){
            isExecuting_ = false;
        }
        private void OnMovementStarted(){
            isExecuting_ = true;
        }
    }
}

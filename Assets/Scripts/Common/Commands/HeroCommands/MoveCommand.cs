using System;
using Entities.Components;
using UnityEngine;
namespace Entities.Commands
{
    public class MoveCommand : HeroCommand
    {
        private GridMovementComponent _gridMovementComponent;
        public MoveCommand(Entity entity) : base(entity){
            _gridMovementComponent = new GridMovementComponent(hero);
            _gridMovementComponent.MovementFinished += OnMovementFinished;
        }

        public override void Execute()
        {
            if (hero != null && hero.SelectedTile != null){
                isExecuting_ = true;
                _gridMovementComponent.Move(hero.SelectedTile);
            }
        }
        private void OnMovementFinished(){
            isExecuting_ = false;
        }
    }
}

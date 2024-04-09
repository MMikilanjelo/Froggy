using GridManagement.Tiles;
using Entities.Components;
using Managers;
using UnityEngine;
using System.Collections;
using Entities.Commands;
namespace Entities
{
    public class Fish : Hero
    {
        CommandManager commandManager = new CommandManager();
        DelegateStateMachine _stateMachine;
        private GridMovementComponent _gridMovementComponent;
        public  void Awake(){
            _gridMovementComponent = new GridMovementComponent(this);
            _stateMachine = new DelegateStateMachine();
            _stateMachine.AddState(MoveState);
        }
        private void Update(){
            _stateMachine.Update();
        }
        private void MoveState(){
        }
        private void OnEnable(){
            commandManager.Test();
           Tile.OnClickTile += SelectTile;
        }
        private void OnDisable() {
            Tile.OnClickTile -= SelectTile;
        }
        private void SelectTile(Tile selectedTile){
            // if(GameManager.Instance.GameState != GameState.HeroesTurn || isTakingAction){
            //     return;
            // }
            // _gridMovementComponent.Move(selectedTile);
            //commandManager.Test();

            commandManager.Test2();

        }
    }
}


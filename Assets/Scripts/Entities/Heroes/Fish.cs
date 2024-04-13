using GridManagement.Tiles;
using Entities.Components;
using Entities.Commands;

namespace Entities
{
    public class Fish : Hero {
        CommandManager commandManager;
        DelegateStateMachine _stateMachine;
        public  void Awake(){
            commandManager = new CommandManager(this);
            _stateMachine = new DelegateStateMachine();
            _stateMachine.AddState(MoveState);
        }
        private void Update(){
            _stateMachine.Update();
        }
        private void MoveState(){
        }
        private void OnEnable(){
            commandManager.SetUpCommands();
            Tile.OnClickTile += SelectTile;
        }
        private void OnDisable() {
            Tile.OnClickTile -= SelectTile;
        }
        private void SelectTile(Tile selectedTile){
            SelectedTile = selectedTile;
            commandManager.Test2();
        }
    }
}


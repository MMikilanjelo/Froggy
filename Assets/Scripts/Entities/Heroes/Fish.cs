using GridManagement.Tiles;
using Entities.Commands;
using Managers;
using UnityEngine;
namespace Entities
{
    public class Fish : Hero {
        private ICommand moveCommand;
        private CommandManager _commandManager;
        public  void Awake(){
            _commandManager = new CommandManager(this);
            moveCommand = HeroCommand.Create<MoveCommand>(this);
            // EventManager.RegisterEvent(EventTypes.GlobalEvents.GridGenerated , Test);
            // EventManager.RegisterEvent(EventTypes.GlobalEvents.LevelStarted, (int x) => testParams(x));
        }
        private void OnEnable(){
            Tile.OnClickTile += SelectTile;
        }
        private void OnDisable() {
            Tile.OnClickTile -= SelectTile;
        }
        private void SelectTile(Tile selectedTile){
            PlayerSelectionManager.Instance.SetSelectedTile(selectedTile);
            _commandManager.ExecuteSingleCommand(moveCommand);
        }
    }
}


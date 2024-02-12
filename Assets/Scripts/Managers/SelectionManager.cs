using UnityEngine;
using GridManagment.Tiles;

namespace Managers
{
    public class SelectionManager : MonoBehaviour , ITileVisitor
    {
        private ISelectable _selectedTile;
        private void OnEnable() => Tile.OnClickTile += DisplayTile;
        private void OnDisable() => Tile.OnClickTile -= DisplayTile;
        private void DisplayTile(Tile tile){
            EventManager<EventTypes.Test , int>.TriggerEvent(EventTypes.Test.Test ,1);
            Visit(tile as ISelectable);
        }
        public void Visit(ISelectable selectableTile)
        {
            if(_selectedTile != null){
                _selectedTile.UnSelect();
                _selectedTile = null;
            }
            _selectedTile = selectableTile;
            _selectedTile.Select();
        }
    }

}

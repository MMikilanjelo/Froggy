using UnityEngine;
using GridManagement.Tiles;
using Managers.Selectors;

namespace Managers
{
    public class SelectionManager : MonoBehaviour
    {
        public static  SelectionManager Instance;
        private TileSelectionHandler _tileSelectionHandler;

        private void Awake() {
            Instance = this;
            _tileSelectionHandler = new TileSelectionHandler();
        }
        public void SelectTile(Tile tile) {
            _tileSelectionHandler.Visit(tile as ISelectable);
        }
        public void HightLightTiles(){
            _tileSelectionHandler.HightLightTiles();
        }
        public void UnHightLightTiles(){
            _tileSelectionHandler.UnHightLightTiles();
        }
    }
    public enum SelectionType{
        MoveSelection,
        
    }
}

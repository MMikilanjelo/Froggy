using UnityEngine;
using GridManagement.Tiles;
using Managers.Selectors;

namespace Managers
{
    public class SelectionManager : MonoBehaviour
    {
        private TileSelectionHandler _tileSelectionHandler;
        private void OnEnable() => Tile.OnClickTile += DisplayTile;
        private void OnDisable() => Tile.OnClickTile -= DisplayTile;
        private void Awake() => _tileSelectionHandler = new TileSelectionHandler();
        private void DisplayTile(Tile tile){
            _tileSelectionHandler.Visit(tile as ISelectable);
            Debug.Log(tile.OccupiedEntity);
        }
    }
}

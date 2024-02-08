using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridManagment.Tiles;
using Unity.VisualScripting;

public class SelectionManager : MonoBehaviour
{
    private Tile _selectedTile;
    private void OnEnable() => Tile.OnClickTile += DisplayTile;
     private void OnDisable() => Tile.OnClickTile -= DisplayTile;
    private void DisplayTile(Tile tile)
    {
        UnSelectPreviousTile();
        SelectTile(tile);
       
    }
    private void SelectTile(Tile tile)
    {
        if(tile is not ISelectable) return;
        _selectedTile = tile;
        (_selectedTile as ISelectable).Select();
        
    }
    private void UnSelectPreviousTile()
    {
        if(_selectedTile != null) {
            (_selectedTile as ISelectable).UnSelect();
        }
        _selectedTile = null;
    }


}

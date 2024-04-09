using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace Managers.Selectors
{

    public class TileSelectionHandler : ITileVisitor
    {
        private HashSet<ISelectable> _selectedTiles = new HashSet<ISelectable>();
        public void Visit(ISelectable selectableTile)=> _selectedTiles.Add(selectableTile);
        public void HightLightTiles(){
            foreach( var tile in _selectedTiles){
                tile.Select();
            }
        }
        public void UnHightLightTiles(){
            foreach( var tile in _selectedTiles){
                tile.UnSelect();
            }
            _selectedTiles.Clear();
        }
    }
}

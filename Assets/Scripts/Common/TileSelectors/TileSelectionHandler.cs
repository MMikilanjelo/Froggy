using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers.Selectors
{

    public class TileSelectionHandler : ITileVisitor
    {
        private ISelectable _selectedTile;

        public void Visit(ISelectable selectableTile){
            if (_selectedTile != null){
                _selectedTile.UnSelect();
                _selectedTile = null;
            }
            _selectedTile = selectableTile;
            _selectedTile.Select();
        }
    }
}

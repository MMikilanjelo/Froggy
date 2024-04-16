using System.Collections;
using System.Collections.Generic;
using GridManagement.Tiles;
using UnityEngine;

namespace Managers{
    public class PlayerSelectionManager : MonoBehaviour
    {
        public static PlayerSelectionManager Instance {get; private set;}
        public Tile SelectedTile{get;private set;}
        private void Awake() => Instance = this;
        
        public void SetSelectedTile(Tile tile){
            SelectedTile = tile;
        }
    }

}

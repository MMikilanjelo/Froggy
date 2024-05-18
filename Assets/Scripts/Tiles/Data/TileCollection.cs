using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Game.GridManagement.Tiles
{
    [CreateAssetMenu(fileName = "TileCollection" , menuName = "TileCollection/TileCollection")] 
    public class TileCollection : ScriptableObject
    {
        [SerializeField] private List <TileData> tiles_;
    
        public IEnumerable<TileData> AllTilesData => tiles_;

        private void OnValidate()
        {
            var tileDuplicates = tiles_.GroupBy(item => item.Type)
                .Where(array => array.Count() > 1);
            
            if(tileDuplicates.Count() > 0){
                throw new InvalidOperationException(nameof(tiles_));    
            }
        }
    }   
}

using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;

namespace GridManagment.Tiles
{
    [CreateAssetMenu(fileName = "TileCollection" , menuName = "TileCollection/TileCollection")] 
    public class TileCollection : ScriptableObject
    {
        [SerializeField] private List <TileData> _tiles;
    
        public IEnumerable<TileData> AllTilesData => _tiles;

        private void OnValidate()
        {
            var tileDuplicates = _tiles.GroupBy(item => item.Type)
                .Where(array => array.Count() > 1);
            
            if(tileDuplicates.Count() > 0){
                throw new InvalidOperationException(nameof(_tiles));    
            }
        }
    }   
}

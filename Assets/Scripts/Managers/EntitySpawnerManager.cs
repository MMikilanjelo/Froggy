using System.Collections;
using System.Collections.Generic;
using Entities;
using GridManagement.Tiles;
using UnityEngine;

namespace Managers
{
    public class EntitySpawnerManager : MonoBehaviour
    {
        [SerializeField] private EntityFactory _entityFactory;
        public static EntitySpawnerManager Instance;
        private List<Hero> _heroes = new List<Hero>();
        private void Awake() => Instance = this;
        public void SpawnHero(Tile tile , EntityTypes.Heroes heroType)
        {
            var hero = _entityFactory.GetHero(heroType);
            if(hero != null){
                var heroInstance =  Instantiate(hero , tile.Coords.Pos , Quaternion.identity);
                heroInstance.SetOccupiedTile(tile);
                tile.SetOccupiedEntity(heroInstance);
                _heroes.Add(heroInstance);
            }
        }
        public void SpawnEnemy(Transform parent) {}

    }
}


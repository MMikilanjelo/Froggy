
using Entities;
using GridManagement.Tiles;
using UnityEngine;

namespace Managers
{
    public class EntitySpawnerManager : MonoBehaviour
    {
        [SerializeField] private EntityFactory _entityFactory;
        public static EntitySpawnerManager Instance;
        private  ObservableList<Hero> heroes_ = new ObservableList<Hero>();
        public  ObservableList<Hero> Heroes => heroes_;
        private void Awake() => Instance = this;
        public void SpawnHero(Tile tile , EntityTypes.Heroes heroType)
        {
            var hero = _entityFactory.GetHero(heroType);
            if(hero != null){
                var heroInstance =  Instantiate(hero , tile.Coords.Pos , Quaternion.identity);
                heroInstance.SetOccupiedTile(tile);
                tile.SetOccupiedEntity(heroInstance);
                
                heroes_.Add(heroInstance);
                EventBus<HeroSpawnedEvent>.Raise(new HeroSpawnedEvent {
                    heroInstance = heroInstance
                });
            }
        }

        public void SpawnEnemy(Transform parent) {
            
        }
                                
    }
    public struct HeroSpawnedEvent : IEvent{
        public Hero heroInstance;
    }
}                   


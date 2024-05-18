using Game.Entities;
using Game.GridManagement.Tiles;
using UnityEngine;
using Game.Utilities.Singletons;
namespace Game.Managers
{
    public class EntitySpawnerManager : Singleton<EntitySpawnerManager>
    {
        [SerializeField] private EntityFactory _entityFactory;
        private  ObservableList<Hero> heroes_ = new ObservableList<Hero>();
        public  ObservableList<Hero> Heroes => heroes_;
        protected override void Awake() => base.Awake();
    
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


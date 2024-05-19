using Game.Entities;
using Game.GridManagement.Tiles;
using UnityEngine;
using Game.Utilities.Singletons;
namespace Game.Managers {
	public class EntitySpawnerManager : Singleton<EntitySpawnerManager> {
		private EntityFactory entityFactory_;
		private ObservableList<Hero> heroes_ = new ObservableList<Hero>();
		public ObservableList<Hero> Heroes => heroes_;
		protected override void Awake() {
			base.Awake();
			entityFactory_ = new EntityFactory();
		}

		public void SpawnHero(Tile tile, HeroTypes heroType) {
			var heroInstance = entityFactory_.SpawnHero(heroType, tile.transform, tile);
			if (heroInstance != null) {
				heroes_.Add(heroInstance);
				EventBus<HeroSpawnedEvent>.Raise(new HeroSpawnedEvent {
					heroInstance = heroInstance
				});
			}
		}

		public void SpawnEnemy(Transform parent) {

		}

	}
	public struct HeroSpawnedEvent : IEvent {
		public Hero heroInstance;
	}
}


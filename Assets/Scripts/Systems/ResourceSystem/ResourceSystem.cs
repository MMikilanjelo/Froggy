using System.Collections;
using System.Collections.Generic;
using Game.Utilities.Singletons;
using Game.GridManagement.Tiles;
using UnityEngine;
using System.Linq;
using Game.Entities;
namespace Game.Systems {
	public class ResourceSystem : Singleton<ResourceSystem> {
		public List<TileData> Tiles { get; private set; }
		public List<HeroData> HeroDatas { get; private set; }
		private Dictionary<HeroTypes, HeroData> heroDataCollection_;
		private Dictionary<TileType, TileData> tileCollection_;
		protected override void Awake() {
			base.Awake();
			AssembleResources();
		}
		private void AssembleResources() {
			Tiles = Resources.LoadAll<TileData>("Tiles").ToList();
			HeroDatas = Resources.LoadAll<HeroData>("Heroes").ToList();

			heroDataCollection_ = HeroDatas.ToDictionary(h => h.Type, h => h);
			tileCollection_ = Tiles.ToDictionary(t => t.Type, t => t);
		}
		private bool TryGetData<K, T>(K key, Dictionary<K, T> collection, out T data) where T : class {
			return collection.TryGetValue(key, out data);
		}

		public bool TryGetTileData(TileType tileType, out TileData tileData) {
			return TryGetData(tileType, tileCollection_, out tileData);
		}

		public bool TryGetHeroData(HeroTypes type, out HeroData heroData) {
			return TryGetData(type, heroDataCollection_, out heroData);
		}
	}
}


using System;
using Game.Entities;
using Game.GridManagement.Tiles;
using Game.Utilities.Singletons;
namespace Game.Managers {
	public class SelectionManager : Singleton<SelectionManager> {
		public Tile SelectedTile { get; private set; }
		public Hero SelectedHero { get; private set; }
		protected override void Awake() {
			base.Awake();
		}
		private void OnEnable() {
			Tile.OnClickTile += OnClickTile;
		}
		private void OnDisable() {
			Tile.OnClickTile -= OnClickTile;
		}
		public void OnClickTile(Tile tile) {
			SelectedTile = tile;
			if (tile.OccupiedEntity is Hero) {
				var hero = tile.OccupiedEntity as Hero;
				UpdateSelectedHero(hero);
			}
		}
		public void RegisterTileSelectionCallback(Action<Tile> callback) {
			Tile.OnClickTile += callback;
		}
		public void DeregisterTileSelectionCallback(Action<Tile> callback) {
			Tile.OnClickTile -= callback;
		}
		public void UpdateSelectedHero(Hero hero) {
			SelectedHero = hero;
			EventBus<HeroSelectedEvent>.Raise(new HeroSelectedEvent {
				hero = SelectedHero
			});
		}

	}
	public struct HeroSelectedEvent : IEvent {
		public Hero hero;
	}
}

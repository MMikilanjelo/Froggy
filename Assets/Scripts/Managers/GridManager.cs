using System.Collections.Generic;
using UnityEngine;
using Game.Utilities.Singletons;
using Game.GridManagement.Tiles;
namespace Game.GridManagement {
	public class GridManager : Singleton<GridManager> {
		[SerializeField] private TileFactory tileFactory_;
		[SerializeField] private ScriptableGrid scriptableGrid_;
		public IReadOnlyDictionary<Vector2, Tile> TilesInGrid;
		protected override void Awake() {
			scriptableGrid_.Initialize(tileFactory_);
		}
		public void GenerateGrid() {
			TilesInGrid = scriptableGrid_.GenerateGrid();
			foreach (var tile in TilesInGrid.Values) {
				tile.CacheNeighbors();
			}

		}
		public Tile GetTileAtPosition(Vector2 position) {
			if (TilesInGrid.TryGetValue(position, out var tile)) {
				return tile;
			}
			return null;
		}
	}
}





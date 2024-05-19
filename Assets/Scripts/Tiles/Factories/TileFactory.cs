using UnityEngine;
using Game.Systems;

namespace Game.GridManagement.Tiles {
	[CreateAssetMenu(fileName = "TileFactory", menuName = "Factory/TileFactory")]
	public class TileFactory : ScriptableObject {
		[SerializeField] private Tile defaultTile_;
		public Tile InstantiateTile(TileType tileType, Transform parent, int q, int r) {
			Tile tileInstance = Instantiate(GetPrefab(tileType), parent);
			tileInstance.Initialize(new HexCoords(q, r));
			return tileInstance;
		}
		private Tile GetPrefab(TileType tileType) {
			if (ResourceSystem.Instance.TryGetTileData(tileType, out TileData tileData)) {
				return tileData.Prefab;
			}
			return defaultTile_;
		}
	}
}


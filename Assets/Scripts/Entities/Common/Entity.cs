using Game.Entities.Characteristic;
using Game.GridManagement.Tiles;
using UnityEngine;

namespace Game.Entities {
	public abstract class Entity : MonoBehaviour {
		
		public Tile OccupiedTile { get; protected set; }
		public Stats Stats => stats_;
		
		protected Stats stats_;
		
		
		public void SetOccupiedTile(Tile tile) => OccupiedTile = tile;
		public abstract bool CanPerformActions();

		
	}
}


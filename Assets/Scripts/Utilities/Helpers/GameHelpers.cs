using Game.Entities;
using Game.Managers;
using System.Collections.Generic;
namespace Game.Helpers {
	public static class GameHelpers {
		public static bool IsPlayerTurn() {
			return GameManager.Instance.GameState == GameState.PlayerTurn;
		}
		public static bool IsRunOutOfActions<T>(List<T> entities) where T : Entity {
				for (int i = 0; i < entities.Count; i++) {
						if (entities[i].CanPerformActions()) {
								return false;
						}
				}
				return true;
		}


	}
}


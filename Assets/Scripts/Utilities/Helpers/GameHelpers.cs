using Game.Entities;
using Game.Managers;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
namespace Game.Helpers {
	public static class GameHelpers {
		public static bool IsPlayerTurn(GameState gameState) {
			return gameState == GameState.PlayerTurn;
		}
		public static bool IsEnemyTurn(GameState gameState) {
			return gameState == GameState.EnemyTurn;
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


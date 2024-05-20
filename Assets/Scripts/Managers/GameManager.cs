using Game.Entities;
using Game.GridManagement;
using UnityEngine;
using Game.Utilities.Singletons;
using System;

namespace Game.Managers {
	public class GameManager : Singleton<GameManager> {
		private GameState gameState_;
		public GameState GameState => gameState_;
		public static event Action<GameState> BeforeGameStateChanged = delegate { };
		public static event Action<GameState> AfterGameStateChanged = delegate { };
		protected override void Awake() {
			base.Awake();
		}
		private void Start() => ChangeGameState(GameState.SetUp);
		public void ChangeGameState(GameState newState) {
			if (gameState_ == newState) {
				Debug.LogWarning($"Ignoring redundant state change: {newState}");
				return;
			}
			BeforeGameStateChanged?.Invoke(newState);

			gameState_ = newState;
			switch (newState) {
				case GameState.SetUp:
					ChangeGameState(GameState.GenerateGrid);
					break;
				case GameState.GenerateGrid:
					GridManager.Instance.GenerateGrid();

					ChangeGameState(GameState.SpawnHeroes);
					break;
				case GameState.SpawnHeroes:

					HandleSpawningHeroesState();
					break;
				case GameState.SpawnEnemies:
					ChangeGameState(GameState.PlayerTurn);
					break;
				case GameState.PlayerTurn:
					break;
				case GameState.EnemyTurn:
					break;
			}
			AfterGameStateChanged?.Invoke(newState);
		}
		private void HandleSpawningHeroesState() {
			EntitySpawnerManager.Instance.SpawnHero(GridManager.Instance.GetTileAtPosition(new Vector2(0, 0)), HeroTypes.Frog);
			EntitySpawnerManager.Instance.SpawnHero(GridManager.Instance.GetTileAtPosition(new Vector2(Mathf.Sqrt(3), 0)), HeroTypes.Fish);
			SelectionManager.Instance.UpdateSelectedHero(EntitySpawnerManager.Instance.Heroes[0]);
			ChangeGameState(GameState.SpawnEnemies);
		}
	}
}
public enum GameState {
	SetUp = -1,
	GenerateGrid = 0,
	SpawnHeroes = 1,
	SpawnEnemies = 2,
	PlayerTurn = 3,
	EnemyTurn = 4,
}




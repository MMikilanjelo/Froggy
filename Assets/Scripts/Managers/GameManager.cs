using Game.Entities;
using Game.GridManagement;
using UnityEngine;
using Game.Utilities.Singletons;
using System;

namespace Game.Managers {
	public class GameManager : Singleton<GameManager> {
		private GameState gameState_ = GameState.SetUp;
		public GameState GameState => gameState_;
		public static event Action BeforeGameStateChanged = delegate { };
		public static event Action AfterGameStateChanged = delegate { };

		protected override void Awake() {
			base.Awake();
		}
		private void Start() => ChangeGameState(GameState.GenerateGrid);
		public void ChangeGameState(GameState newState) {
			if (newState == gameState_) {
				Debug.LogWarning($"Ignoring redundant state change: {newState}");
				return;
			}
			BeforeGameStateChanged?.Invoke();
			gameState_ = newState;

			switch (newState) {
				case GameState.GenerateGrid:
					GridManager.Instance.GenerateGrid();
					ChangeGameState(GameState.SpawnHeroes);
					break;
				case GameState.SpawnHeroes:
					EntitySpawnerManager.Instance.SpawnHero(GridManager.Instance.GetTileAtPosition(new Vector2(0, 0)),
							HeroTypes.Frog);
					EntitySpawnerManager.Instance.SpawnHero(GridManager.Instance.GetTileAtPosition(new Vector2(Mathf.Sqrt(3), 0)),
							HeroTypes.Fish);
					SelectionManager.Instance.UpdateSelectedHero(EntitySpawnerManager.Instance.Heroes[0]);
					ChangeGameState(GameState.PlayerTurn);
					break;
				case GameState.SpawnEnemies:
					break;
				case GameState.PlayerTurn:
					
					break;
				case GameState.EnemiesTurn:
					break;
			}
			AfterGameStateChanged?.Invoke();
		}

	}
}
public enum GameState {
	SetUp = -1,
	GenerateGrid = 0,
	SpawnHeroes = 1,
	SpawnEnemies = 2,
	PlayerTurn = 3,
	EnemiesTurn = 4,
}
public enum TurnState {
	StartOfTurn = 0,
	EndOfTurn = 1,
}



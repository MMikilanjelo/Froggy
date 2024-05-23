using Game.Entities;
using Game.GridManagement;
using UnityEngine;
using Game.Utilities.Singletons;
using System;

namespace Game.Managers {
	public class GameManager : Singleton<GameManager> {
		public GameState GameState {get;private set;}
		public static event Action<GameState> BeforeGameStateChanged = delegate { };
		public static event Action<GameState> AfterGameStateChanged = delegate { };
		protected override void Awake() {
			base.Awake();
		}
		private void Start() => ChangeGameState(GameState.SetUp);
		public void ChangeGameState(GameState newState) {
			if (GameState == newState) {
				Debug.LogWarning($"Ignoring redundant state change: {newState}");
				return;
			}
			BeforeGameStateChanged?.Invoke(newState);
			GameState = newState;
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
[Serializable]
public enum GameState {
	None = 0,
	SetUp = 1,
	GenerateGrid = 2,
	SpawnHeroes = 3,
	SpawnEnemies =4,
	PlayerTurn = 5,
	EnemyTurn = 6,
}




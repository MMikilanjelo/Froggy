using System;
using Game.Helpers;
using Game.Utilities.Singletons;

namespace Game.Managers {
	public class TurnManager : Singleton<TurnManager> {

		public static event Action StartPlayerTurn = delegate { };
		public static event Action PlayerTurn = delegate { };
		public static event Action EndOfPlayerTurn = delegate { };

		public static event Action StartEnemyTurn = delegate { };
		public static event Action EnemyTurn = delegate { };
		public static event Action EndOfEnemyTurn = delegate { };

		protected override void Awake() {
			base.Awake();
		}

		private void OnEnable() {
			GameManager.BeforeGameStateChanged += OnBeforeGameStateChanged;
			GameManager.AfterGameStateChanged += OnAfterGameStateChanged;
		}

		private void OnDisable() {
			GameManager.BeforeGameStateChanged -= OnBeforeGameStateChanged;
			GameManager.AfterGameStateChanged -= OnAfterGameStateChanged;
		}

		private void OnBeforeGameStateChanged(GameState newGameState) {
			if (GameHelpers.IsPlayerTurn(GameManager.Instance.GameState) && newGameState == GameState.EnemyTurn) {
				EndOfPlayerTurn?.Invoke();
			}
			if (GameHelpers.IsEnemyTurn(GameManager.Instance.GameState) && newGameState == GameState.PlayerTurn) {
				EndOfEnemyTurn?.Invoke();
			}
		}

		private void OnAfterGameStateChanged(GameState gameState) {

			if (GameHelpers.IsPlayerTurn(gameState)) {
				StartPlayerTurn?.Invoke();
				PlayerTurn?.Invoke();
			}

			if (GameHelpers.IsEnemyTurn(gameState)) {
				StartEnemyTurn?.Invoke();
				EnemyTurn?.Invoke();
			}
		}
	}
}

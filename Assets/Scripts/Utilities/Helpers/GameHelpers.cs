using Game.Managers;
namespace Game.Helpers {
	public static class GameHelpers {
		public static  bool CheckPlayerTurn() {
			return GameManager.Instance.GameState == GameState.PlayerTurn ? true : false;
		}
		
	}
}


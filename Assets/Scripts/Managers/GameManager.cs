using Game.Entities;
using Game.GridManagement;
using UnityEngine;
using Game.Utilities.Singletons;

namespace Game.Managers
{
    public class GameManager : Singleton<GameManager>
    {
        private GameState gameState_;
        public GameState GameState => gameState_;
        private PlayerController player_;
        protected override void Awake() {
            base.Awake();
            player_ = FindObjectOfType<PlayerController>();
        }
        private void Start() => ChangeGameState(GameState.GenerateGrid);
        public void ChangeGameState(GameState newState)
        {
            gameState_ = newState;
            switch (newState)
            {
                case GameState.GenerateGrid:
                    GridManager.Instance.GenerateGrid();
                    ChangeGameState(GameState.SpawnHeroes);
                    break;
                case GameState.SpawnHeroes:
                    EntitySpawnerManager.Instance.SpawnHero(GridManager.Instance.GetTileAtPosition(new Vector2(0, 0)),
                        EntityTypes.Heroes.Frog);
                    EntitySpawnerManager.Instance.SpawnHero(GridManager.Instance.GetTileAtPosition(new Vector2(Mathf.Sqrt(3), 0)),
                        EntityTypes.Heroes.Fish);
                    PlayerSelectionManager.Instance.UpdateSelectedHero(EntitySpawnerManager.Instance.Heroes[0]);
                    ChangeGameState(GameState.PlayerTurn);  
                    break;
                case GameState.SpawnEnemies:
                    break;
                case GameState.PlayerTurn:
                    //player_.PerformTurn();
                    break;
                case GameState.EnemiesTurn:
                    break;
            }
        }

    }
}
public enum GameState
{
    GenerateGrid = 0,
    SpawnHeroes = 1,
    SpawnEnemies = 2,
    PlayerTurn = 3,
    EnemiesTurn = 4,
}
public enum TurnState{
    StartOfTurn =  0,
    EndOfTurn = 1,
}



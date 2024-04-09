using Entities;
using GridManagement;
using UnityEngine;


namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        private GameState _gameState;
        public GameState GameState => _gameState;
        private void Awake() => Instance = this;
        private void Start() => ChangeGameState(GameState.GenerateGrid);
        public void ChangeGameState(GameState newState)
        {
            _gameState = newState;
            switch (newState)
            {
                case GameState.GenerateGrid:
                    GridManager.Instance.GenerateGrid();
                    ChangeGameState(GameState.SpawnHeroes);
                    break;
                case GameState.SpawnHeroes:
                    EntitySpawnerManager.Instance.SpawnHero
                    (GridManager.Instance.GetTileAtPosition(new Vector2(0, 0)),
                    EntityTypes.Heroes.Fish);
                    ChangeGameState(GameState.HeroesTurn);  
                    break;
              
                case GameState.SpawnEnemies:
                    break;
                case GameState.HeroesTurn:
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
    HeroesTurn = 3,
    EnemiesTurn = 4,
}


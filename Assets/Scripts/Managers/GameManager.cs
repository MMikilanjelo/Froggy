using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        private GameState _gameState;
        public GameState GameState => _gameState;
        private void Awake() => Instance = this;
        public void ChangeGameState(GameState newState)
        {
            _gameState = newState;
            switch(newState)
            {
                case GameState.GenerateGrid:
                    break;
                case GameState.SpawnHeroes:
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
    GenerateGrid = 0 ,
    SpawnHeroes = 1 ,
    SpawnEnemies = 2 ,
    HeroesTurn = 3,
    EnemiesTurn = 4,
}


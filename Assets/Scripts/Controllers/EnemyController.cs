using System.Collections;
using System.Collections.Generic;
using Game.Managers;
using UnityEngine;

namespace Game.Controllers {
	public class EnemyController : MonoBehaviour {
		private void OnEnable() {

			TurnManager.StartEnemyTurn += OnStartEnemyTurn;
			TurnManager.EnemyTurn += OnEnemyTurn;
			TurnManager.EndOfEnemyTurn += OnEndOfEnemyTurn;

		}
		private void OnDisable() {

			TurnManager.StartEnemyTurn += OnStartEnemyTurn;
			TurnManager.EnemyTurn += OnEnemyTurn;
			TurnManager.EndOfEnemyTurn += OnEndOfEnemyTurn;

		}
		private void OnStartEnemyTurn() {
			Debug.Log("Ahahahah mu turn");
		}
		private void OnEnemyTurn() {
		}
		private void OnEndOfEnemyTurn() {
		}

	}

}

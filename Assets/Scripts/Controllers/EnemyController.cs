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
			Debug.Log("Do some logic related to starting of Enemy turn");
		}
		private void OnEnemyTurn() {
			Debug.Log("Starting courutine of enemy turn");
		}
		private void OnEndOfEnemyTurn() {
			Debug.Log("CleanUp of Enemy turn Turn");
		}

	}

}

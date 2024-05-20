using System.Collections.Generic;
using Game.Entities;
using Game.Managers;
using UnityEngine;
namespace Game.Controllers {


	public class PlayerController : MonoBehaviour {
		private IList<Hero> heroes_ = new List<Hero>();
		private EventBinding<HeroSpawnedEvent> heroSpawnedEventBinding_;
		private void OnEnable() {
			heroSpawnedEventBinding_ = new EventBinding<HeroSpawnedEvent>(OnHeroSpawned);
			EventBus<HeroSpawnedEvent>.Register(heroSpawnedEventBinding_);

			TurnManager.StartPlayerTurn += OnStartPlayerTurn;
			TurnManager.PlayerTurn += OnPlayerTurn;
			TurnManager.EndOfPlayerTurn += OnEndOfPlayerTurn;

		}
		private void OnDisable() {
			EventBus<HeroSpawnedEvent>.Deregister(heroSpawnedEventBinding_);
			StopAllCoroutines();

			TurnManager.StartPlayerTurn -= OnStartPlayerTurn;
			TurnManager.PlayerTurn -= OnPlayerTurn;
			TurnManager.EndOfPlayerTurn -= OnEndOfPlayerTurn;
		}
		private void OnStartPlayerTurn() {
			Debug.Log("Do some logic related to starting of Player Turn");
		}
		private void OnPlayerTurn() {
			Debug.Log("Starting courutine of player turn");
		}
		private void OnEndOfPlayerTurn() {
			Debug.Log("CleanUp of Player Turn");
		}

		private void Update() {
			if (Input.GetKeyDown(KeyCode.Space)) {
				GameManager.Instance.ChangeGameState(GameState.EnemyTurn);
			}
			if (Input.GetKeyDown(KeyCode.W)) {
				GameManager.Instance.ChangeGameState(GameState.PlayerTurn);
			}
		}
		private void OnHeroSpawned(HeroSpawnedEvent heroSpawnedEvent) {
			heroes_.Add(heroSpawnedEvent.heroInstance);
		}
	}
}
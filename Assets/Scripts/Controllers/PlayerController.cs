using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Game.Entities;
using Game.Helpers;
using Game.Managers;
using Unity.Collections;
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
			StartCoroutine(PlayerTurnCoroutine());
		}
		private IEnumerator PlayerTurnCoroutine() {
			yield return new WaitUntil(() => GameHelpers.IsRunOutOfActions(heroes_ as List<Hero>));
			GameManager.Instance.ChangeGameState(GameState.EnemyTurn);
		}
		private void OnPlayerTurn() {
		}
		private void OnEndOfPlayerTurn() {
			StopCoroutine(PlayerTurnCoroutine());
		}

		// private void Update() {
		// 	if (Input.GetKeyDown(KeyCode.Space)) {
		// 		GameManager.Instance.ChangeGameState(GameState.EnemyTurn);
		// 	}
		// 	if (Input.GetKeyDown(KeyCode.W)) {
		// 		GameManager.Instance.ChangeGameState(GameState.PlayerTurn);
		// 	}
		// }
		private void OnHeroSpawned(HeroSpawnedEvent heroSpawnedEvent) {
			heroes_.Add(heroSpawnedEvent.heroInstance);
		}
	}
}
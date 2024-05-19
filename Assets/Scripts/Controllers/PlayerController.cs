using System.Collections.Generic;
using Game.Entities;
using Game.Managers;
using UnityEngine;
using Game.Helpers;
using System.Linq;
public class PlayerController : MonoBehaviour {
	private IList<Hero> heroes_ = new List<Hero>();
	private EventBinding<HeroSpawnedEvent> heroSpawnedEventBinding_;
	private bool guard_ = false;
	private void OnEnable() {
		heroSpawnedEventBinding_ = new EventBinding<HeroSpawnedEvent>(OnHeroSpawned);
		EventBus<HeroSpawnedEvent>.Register(heroSpawnedEventBinding_);
		GameManager.AfterGameStateChanged += OnGameStateChanged;
	}
	private void OnDisable() {
		EventBus<HeroSpawnedEvent>.Deregister(heroSpawnedEventBinding_);
		StopAllCoroutines();
	}
	private void Update(){
		if(guard_){
			return;
		}
		if(GameHelpers.IsRunOutOfActions(heroes_ as List<Hero>)){
			GameManager.Instance.ChangeGameState(GameState.EnemiesTurn);
			guard_ = true;
		}
	}
	private void OnHeroSpawned(HeroSpawnedEvent heroSpawnedEvent) {
		heroes_.Add(heroSpawnedEvent.heroInstance);
	}
	private void OnGameStateChanged(){
		if(GameHelpers.IsPlayerTurn()){

		}
	}
}

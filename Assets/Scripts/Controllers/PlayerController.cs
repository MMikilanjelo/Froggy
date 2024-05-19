using System.Collections;
using System.Collections.Generic;
using Game.Entities;
using Game.Managers;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	private IList<Hero> heroes_ = new List<Hero>();
	private EventBinding<HeroSpawnedEvent> heroSpawnedEventBinding_;
	private void OnEnable() {
		heroSpawnedEventBinding_ = new EventBinding<HeroSpawnedEvent>(OnHeroSpawned);
		EventBus<HeroSpawnedEvent>.Register(heroSpawnedEventBinding_);
	}
	private void OnDisable() {
		EventBus<HeroSpawnedEvent>.Deregister(heroSpawnedEventBinding_);
		StopAllCoroutines();
	}
	private void OnHeroSpawned(HeroSpawnedEvent heroSpawnedEvent) {
		heroes_.Add(heroSpawnedEvent.heroInstance);
	}

}

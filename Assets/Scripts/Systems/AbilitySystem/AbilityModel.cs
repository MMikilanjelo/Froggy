using System.Collections.Generic;
using Game.Entities;
using Game.Managers;

namespace Game.Architecture.AbilitySystem {
	public class AbilityModel {
		EventBinding<HeroSpawnedEvent> heroSpawnedEventBinding_;
		public readonly Dictionary<Hero, ObservableList<Ability>> abilities_ = new Dictionary<Hero, ObservableList<Ability>>();
		public void Initialize() {
			heroSpawnedEventBinding_ = new EventBinding<HeroSpawnedEvent>(OnHeroSpawned);
			EventBus<HeroSpawnedEvent>.Register(heroSpawnedEventBinding_);
		}
		private void OnHeroSpawned(HeroSpawnedEvent heroSpawnedEvent) {
			var heroAbilities = new ObservableList<Ability>();
			for(int i = 0; i< heroSpawnedEvent.heroInstance.Abilities.Count ; i ++){
				heroAbilities.Add(heroSpawnedEvent.heroInstance.Abilities[i]);
			}

			abilities_.Add(heroSpawnedEvent.heroInstance, heroAbilities);
		}
	}
}
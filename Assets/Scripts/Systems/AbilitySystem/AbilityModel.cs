using System.Collections.Generic;
using Game.Entities;
using Game.Managers;

namespace Game.Architecture.AbilitySystem{
    public class AbilityModel
    {
        EventBinding<HeroSpawnedEvent> heroSpawnedEventBinding; 
        public readonly Dictionary<Hero , ObservableList<Ability>> abilities_ = new Dictionary<Hero, ObservableList<Ability>>();
        public void Initialize(){
            heroSpawnedEventBinding = new EventBinding<HeroSpawnedEvent>(OnHeroSpawned);
            EventBus<HeroSpawnedEvent>.Register(heroSpawnedEventBinding);
        }
        private void OnHeroSpawned(HeroSpawnedEvent heroSpawnedEvent){
            var heroAbilities = new ObservableList<Ability>(); 
            foreach (var ability in heroSpawnedEvent.heroInstance.Abilities) {
                heroAbilities.Add(ability);
            }
            abilities_.Add(heroSpawnedEvent.heroInstance, heroAbilities);
        }
    }
}
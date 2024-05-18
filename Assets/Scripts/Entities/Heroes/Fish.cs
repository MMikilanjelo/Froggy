using Game.Entities;
using Game.Architecture.AbilitySystem;

namespace Entities
{
    public class Fish : Hero {
        private AbilityFactory abilityFactory_;
        public void Awake(){
            abilityFactory_ = new AbilityFactory(this);
            abilities_ = abilityFactory_.CreateEntityAbilities(abilityInformation);
        }
    }
}


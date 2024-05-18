using Game.Architecture.AbilitySystem;
using Game.Entities;

using UnityEngine;
namespace Entities
{
    public class Frog : Hero
    {
        private AbilityFactory abilityFactory_;
        public void Awake() {
            abilityFactory_ = new AbilityFactory(this);
            abilities_ = abilityFactory_.CreateEntityAbilities(abilityInformation);
        }
    }
}


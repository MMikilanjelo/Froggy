using System.Collections.Generic;
using Game.Architecture.AbilitySystem;
using Game.Entities.Characteristic;

namespace Game.Entities {
	public abstract class Hero : Entity {
		
		public List<Ability> Abilities => abilities_;
		
		protected List<Ability> abilities_;
		protected AbilityFactory abilityFactory_;
		protected virtual void Awake(){
			abilityFactory_ = new AbilityFactory(this);
		}
		public virtual void Initialize(AbilityDefinition[] abilityInformation , Stats stats) {
			abilities_ = abilityFactory_.CreateEntityAbilities(abilityInformation);
			stats_ = stats;
		}

	}
}


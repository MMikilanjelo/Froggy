using System.Collections.Generic;
using Game.Architecture.AbilitySystem;
using UnityEditor;
using UnityEngine;
namespace Game.Entities {
	public abstract class Hero : Entity {
		public List<Ability> Abilities => abilities_;
		protected List<Ability> abilities_;
		protected AbilityFactory abilityFactory_;
		public virtual void InitializeAbilities(AbilityDefinition[] abilityInformation) {
			abilities_ = abilityFactory_.CreateEntityAbilities(abilityInformation);
		}	
	}
}


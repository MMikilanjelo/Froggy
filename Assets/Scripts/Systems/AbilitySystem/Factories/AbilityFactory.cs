using System;
using System.Collections.Generic;
using Game.Entities;
using Game.Entities.Commands;

namespace Game.Architecture.AbilitySystem {
	public class AbilityFactory {
		private Entity entity_;
		public AbilityFactory(Entity entity) {
			entity_ = entity;
		}

		private Ability CreateAbility(AbilityDefinition abilityInformation) {
			if (abilityInformation.abilityData == null) {
				return null;
			}
			switch (abilityInformation.abilityType) {
				case AbilityType.MoveAbility:
					return new Ability(HeroCommand.Create<MoveCommand>(entity_), abilityInformation.abilityData);
				case AbilityType.AttackAbility:
					return new Ability(HeroCommand.Create<AttackCommand>(entity_), abilityInformation.abilityData);
			}
			return null;
		}
		public List<Ability> CreateEntityAbilities(AbilityDefinition[] abilityInformation) {
			List<Ability> abilities = new List<Ability>();
			for (int i = 0; i < abilityInformation.Length; i++) {
				abilities.Add(CreateAbility(abilityInformation[i]));
			}
			return abilities;
		}
	}
	public enum AbilityType {
		MoveAbility,
		AttackAbility,
	}

	[Serializable]
	public struct AbilityDefinition {
		public AbilityType abilityType;
		public AbilityData abilityData;
	}
}


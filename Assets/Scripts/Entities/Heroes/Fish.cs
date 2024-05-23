using Game.Architecture.AbilitySystem;
using Game.Entities;
using Game.Entities.Characteristic;
using Game.Entities.Components;
using UnityEngine;


namespace Entities {
	public class Fish : Hero {
		public TurnCounterComponent TurnCounterComponent { get; private set; }
		public override bool CanPerformActions() => TurnCounterComponent.CanPerformActions;
		protected override void Awake() {
			base.Awake();

		}
		public override void Initialize(AbilityDefinition[] abilityInformation, Stats stats) {
			base.Initialize(abilityInformation, stats);
			SetUpComponents();
		}
		private void SetUpComponents() {
			TurnCounterComponent = new TurnCounterComponent(Stats.ActionsCount);
		}
	}
}


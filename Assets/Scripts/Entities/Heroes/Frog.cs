using Game.Entities.Components;
using Game.Architecture.AbilitySystem;
using Game.Entities;
using Game.Entities.Characteristic;
using UnityEngine;

namespace Entities {
	public class Frog : Hero {
		public TurnCounterComponent TurnCounterComponent { get; private set; }

		protected override void Awake() {
			base.Awake();
		}
		public override void Initialize(AbilityDefinition[] abilityInformation, Stats stats) {
			base.Initialize(abilityInformation, stats);
			SetUpComponents();
		}
		public override bool CanPerformActions() => TurnCounterComponent.CanPerformActions;
		
		private void SetUpComponents() {
			TurnCounterComponent = new TurnCounterComponent(Stats.ActionsCount);
		}
		private void Update(){
			if(Input.GetKeyDown(KeyCode.Space)){
				TurnCounterComponent.PerformAction();
			}
		}
	
	}
}


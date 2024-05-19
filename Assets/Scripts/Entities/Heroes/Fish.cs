using Game.Entities;
using Game.Architecture.AbilitySystem;

namespace Entities {
	public class Fish : Hero {
		public void Awake() {
			abilityFactory_ = new AbilityFactory(this);
		}
	}
}


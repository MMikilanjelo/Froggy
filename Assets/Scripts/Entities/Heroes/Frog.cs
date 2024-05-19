using Game.Architecture.AbilitySystem;
using Game.Entities;

using UnityEngine;
namespace Entities {
	public class Frog : Hero {
		public void Awake() {
			abilityFactory_ = new AbilityFactory(this);
		}
	}
}


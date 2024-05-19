using UnityEngine;

namespace Game.Architecture.AbilitySystem {
	[CreateAssetMenu(fileName = "AbilityData", menuName = "AbilityData/PlayerAbilityData")]
	public class AbilityData : ScriptableObject {
		public Sprite icon;
		public string fullName;
	}
}



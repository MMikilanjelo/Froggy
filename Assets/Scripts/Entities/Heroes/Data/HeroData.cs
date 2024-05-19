using Game.Architecture.AbilitySystem;
using UnityEngine;

namespace Game.Entities {
	[CreateAssetMenu(fileName = "EntityData", menuName = "Entity/Data/HeroData")]
	public class HeroData : EntityData {
		[SerializeField] public AbilityDefinition[] AbilitiesDefinitions;
		[SerializeField] public Hero Prefab;
		[SerializeField] public HeroTypes Type;

	}

}


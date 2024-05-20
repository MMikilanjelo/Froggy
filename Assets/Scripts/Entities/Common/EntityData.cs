
using Game.Entities.Characteristic;
using UnityEngine;

namespace Game.Entities {
	public abstract class EntityData : ScriptableObject {
		[SerializeField] public Stats Stats;
	}

}


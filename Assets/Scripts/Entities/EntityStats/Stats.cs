
using UnityEngine;
namespace Game.Entities.Characteristic {
	[CreateAssetMenu(fileName = "EntityStats", menuName = "Entity/Stats/EntityStats")]
	public class Stats : ScriptableObject {
		[SerializeField] private int movmentDistance_;
		[SerializeField] private int actionsCount_;
		public int MovmentDistance => movmentDistance_;
		public int ActionsCount => actionsCount_;
	}
}


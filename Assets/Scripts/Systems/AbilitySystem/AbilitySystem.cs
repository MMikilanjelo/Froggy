using UnityEngine;

namespace Game.Architecture.AbilitySystem {
	public class AbilitySystem : MonoBehaviour {
		[SerializeField] AbilityView view_;
		AbilityController controller_;

		void Awake() {
			controller_ = new AbilityController.Builder()
			.WithModel()
			.Build(view_);
		}
	}
}


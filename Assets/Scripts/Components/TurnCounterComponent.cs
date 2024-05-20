
using Unity.Mathematics;
using UnityEngine;

namespace Game.Entities.Components {
	public class TurnCounterComponent {
		private int maxActions_;
		private int remainingActions_;
		
		public bool CanPerformActions => remainingActions_ > 0; 
		public int MaxActions => maxActions_;
		public int RemainingActions => remainingActions_;
		
		public TurnCounterComponent(int maxActions){
			maxActions_ = maxActions;
			remainingActions_ = maxActions_;
		}
		public void ResetActions(){
			remainingActions_ = maxActions_;
		}
		public void PerformAction() {
			remainingActions_ -= 1;
			remainingActions_ = Mathf.Clamp(remainingActions_ , 0 , maxActions_);
		}
	}
}


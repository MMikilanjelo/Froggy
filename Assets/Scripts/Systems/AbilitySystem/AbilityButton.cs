using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

namespace Game.Architecture.AbilitySystem {
	public class AbilityButton : MonoBehaviour {
		public Image abilityIcon;
		public Key key;
		public int index;
		public Text label;
		public Action<int> OnButtonPressed = delegate { };
		private Button button_;
		void Awake() {
			button_ = GetComponent<Button>();
			button_.onClick.AddListener(() => OnButtonPressed(index));
		}
		public void Initialize(int index, Key key) {
			this.key = key;
			this.index = index;
		}
		void Update() {
			if (Keyboard.current[key].wasPressedThisFrame) {
				OnButtonPressed(index);
			}
		}
		public void RegisterListener(Action<int> listener) {
			OnButtonPressed += listener;
		}
		public void UnregisterListeners(Action<int> listener) {
			OnButtonPressed -= listener;
		}

		public void UpdateButtonSprite(Sprite newIcon) {
			abilityIcon.sprite = newIcon;
		}
		public void UpdateButtonText(string text) {
			label.text = text;
		}
		public void SetButtonInteractable(bool interactable) {
			button_.interactable = interactable;
		}
	}
}


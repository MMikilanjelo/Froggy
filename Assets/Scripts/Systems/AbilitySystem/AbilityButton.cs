using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

namespace Game.Architecture.AbilitySystem
{
    public class AbilityButton : MonoBehaviour
    {
        public Image abilityIcon;
        public Key key;
        public int index;
        public Text label;
        public Action<int> OnButtonPressed = delegate { };
        void Start(){
            GetComponent<Button>().onClick.AddListener(() => OnButtonPressed(index));
        }
        void Update(){
            if (Keyboard.current[key].wasPressedThisFrame){
                OnButtonPressed(index);
            }
        }
        public void RegisterListener(Action<int> listener){
            OnButtonPressed += listener;
        }
        public void UnregisterListeners(Action<int> listener){
            OnButtonPressed -= listener;
        }
        public void Initialize(int index, Key key){
            this.key = key;
            this.index = index;
        }
        public void UpdateButtonSprite(Sprite newIcon) {
            abilityIcon.sprite = newIcon;
        }
        public void UpdateButtonText(string text){
            label.text = text;
        }
    }
}


using System.Collections.Generic;
using Architecture.AbilitySystem;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class AbilityView : MonoBehaviour
{
    [SerializeField] public AbilityButton[] buttons;
    readonly Key[] keys = { Key.Digit1  , Key.Digit2};
    void Awake(){
        for(int i = 0 ; i < buttons.Length ; i ++){
            if (i >= keys.Length) {
                Debug.LogError("Not enough keycodes for the number of buttons.");
                break;
            }
            buttons[i].Initialize(i, keys[i]);
        }
    }
    public void UpdateButtonSprites(IList<Ability> abilities){
        for(int i = 0 ; i < buttons.Length ; i ++){
            if(i < abilities.Count){
                //buttons[i].UpdateButtonSprite(abilities[i].Data.icon);
                buttons[i].UpdateButtonText(abilities[i].Data.fullName);
            }
            else {
                buttons[i].gameObject.SetActive(false);
            }
        }
    }

}

using UnityEngine;

namespace Game.Architecture.AbilitySystem
{
    public class AbilitySystem : MonoBehaviour
    {
        [SerializeField] AbilityView view;
        AbilityController controller;

        void Awake(){
            controller = new AbilityController.Builder()
            .WithModel()
            .Build(view);
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Entities
{
    [CreateAssetMenu(fileName ="EntityFactory" , menuName = "Factory/EntityFactory")]

    public class EntityFactory : ScriptableObject
    {
        [SerializeField] public Hero Fish;
        public Hero GetHero(EntityTypes.Heroes heroType){
            switch(heroType)
            {
                case EntityTypes.Heroes.Fish:
                    return Fish;
                default:
                    Debug.LogError("Unknown entity type: " + heroType);
                    return null;
            }
        }
    }
    public static class EntityTypes
    {
        public enum Heroes{
            Fish,

        }
    }
}


using UnityEngine;

namespace Game.Entities
{
    [CreateAssetMenu(fileName ="EntityFactory" , menuName = "Factory/EntityFactory")]

    public class EntityFactory : ScriptableObject
    {
        [SerializeField] public Hero fish;
        [SerializeField] public Hero frog;
        public Hero GetHero(EntityTypes.Heroes heroType){
            switch(heroType)
            {
                case EntityTypes.Heroes.Fish:
                    return fish;
                case EntityTypes.Heroes.Frog:
                    return frog;
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
            Frog

        }
    }
}


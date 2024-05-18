using System.Collections.Generic;
using Game.Architecture.AbilitySystem;
using UnityEngine;
namespace Game.Entities
{
    public abstract class Hero : Entity
    {
        [SerializeField] protected AbilityInformation[] abilityInformation;
        protected List<Ability> abilities_;
        public List<Ability> Abilities => abilities_;
    }
}   


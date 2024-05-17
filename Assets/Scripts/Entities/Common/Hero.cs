using System.Collections.Generic;
using Architecture.AbilitySystem;
using UnityEngine;
namespace Entities
{
    public abstract class Hero : Entity
    {
        [SerializeField] protected AbilityInformation[] abilityInformation;
        protected List<Ability> abilities_;
        public List<Ability> Abilities => abilities_;
    }
}   


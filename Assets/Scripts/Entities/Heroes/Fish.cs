using GridManagement.Tiles;
using Entities.Commands;
using Managers;
using Architecture.AbilitySystem;
using System.Collections.Generic;
using UnityEngine;
namespace Entities
{
    public class Fish : Hero {
        private AbilityFactory abilityFactory_;
        public void Awake(){
            abilityFactory_ = new AbilityFactory(this);
            abilities_ = abilityFactory_.CreateEntityAbilities(abilityInformation);
        }
    }
}


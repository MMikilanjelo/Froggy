
using System;
using System.Collections.Generic;
using System.Linq;
using Architecture.AbilitySystem;
using Entities.Commands;
using GridManagement.Tiles;

using UnityEngine;
namespace Entities
{
    public class Frog : Hero
    {
        private AbilityFactory abilityFactory_;
        public void Awake() {
            abilityFactory_ = new AbilityFactory(this);
            abilities_ = abilityFactory_.CreateEntityAbilities(abilityInformation);
        }
    }
}


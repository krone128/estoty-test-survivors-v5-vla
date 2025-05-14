using System.Collections.Generic;
using Code.Gameplay.UnitStats.Behaviours;
using Code.Infrastructure;
using UnityEngine;

namespace Code.Gameplay.Lifetime.Behaviours
{
    [RequireComponent(typeof(Stats))]
    public class PlayerAbilities : MonoBehaviour
    {
        private IList<IPlayerUpgrade> _appliedUpgrades = new List<IPlayerUpgrade>();

        public void AddUpgrade(IPlayerUpgrade upgrade)
        {
            
        }

        public bool IsApplicable(IPlayerUpgrade upgrade)
        {
            return !upgrade.FullyUpgraded;
        }
    }
} 
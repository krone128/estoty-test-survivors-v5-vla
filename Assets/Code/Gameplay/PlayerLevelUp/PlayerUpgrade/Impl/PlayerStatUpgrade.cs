using System.Collections.Generic;
using Code.Gameplay.Characters.Heroes.Services;
using Code.Gameplay.UnitStats;
using UnityEngine;

namespace Code.Infrastructure
{
    public class PlayerStatUpgrade : PlayerUpgrade
    {
        protected StatModifier _statModifier;

        public PlayerStatUpgrade(StatType statType, int upgradeStep, int maxLevel, string description, Sprite icon) 
            : base(maxLevel, description, icon)
        {
            _statModifier = new StatModifier(statType, upgradeStep);
            Description = string.Format(description, statType, upgradeStep);
            ViewModel.Description = Description;
        }

        public override void Remove(IHeroProvider heroProvider)
        {
            if(_statModifier.LinkedStatType != StatType.Unknown)
            {
                heroProvider.Stats.RemoveStatModifier(_statModifier);
            }
        }

        protected override void ApplyToTarget(IHeroProvider heroProvider)
        {
            heroProvider.Stats.AddStatModifier(_statModifier);
            
            Debug.Log($"StatsPlayerUpgrade: Adding stat modifier {_statModifier.LinkedStatType} +{_statModifier.Value}" +
                      $" => {heroProvider.Stats.GetStat(_statModifier.LinkedStatType)}");
        }
    }
}
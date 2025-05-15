using Code.Gameplay.Characters.Heroes.Services;
using Code.Gameplay.Guns.Behaviours;
using Code.Gameplay.UnitStats;
using Code.Gameplay.UnitStats.Behaviours;
using UnityEngine;

namespace Code.Infrastructure
{
    public class GunStatUpgrade : PlayerStatUpgrade
    {
        public GunStatUpgrade(StatType statType, int upgradeStep, int maxLevel, string description, Sprite icon) 
            : base(statType, upgradeStep, maxLevel,  description, icon)
        {
            
        }

        public override void Remove(IHeroProvider heroProvider)
        {
            if(_statModifier.LinkedStatType != StatType.Unknown)
            {
                heroProvider.Hero.GetComponent<GunOwner>().OwnedGun
                    .GetComponent<Stats>()
                    .RemoveStatModifier(_statModifier);
            }
        }

        protected override void ApplyToTarget(IHeroProvider heroProvider)
        {
            heroProvider.Hero.GetComponent<GunOwner>().OwnedGun
                .GetComponent<Stats>()
                .AddStatModifier(_statModifier);
            
            Debug.Log($"GunStatUpgrade: Adding stat modifier {_statModifier.LinkedStatType} +{_statModifier.Value}" +
                      $" => {heroProvider.Stats.GetStat(_statModifier.LinkedStatType)}");
        }
    }
}
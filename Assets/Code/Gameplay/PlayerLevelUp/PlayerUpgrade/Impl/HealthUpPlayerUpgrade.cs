using Code.Gameplay.Characters.Heroes.Services;
using Code.Gameplay.UnitStats;
using Code.Infrastructure;
using UnityEngine;

namespace Code.Gameplay.PlayerLevelUp.PlayerUpgrade.Impl
{
    public class HealthUpPlayerUpgrade : StatsPlayerUpgrade
    {
        public HealthUpPlayerUpgrade(StatType statType, int upgradeStep, int maxLevel, string description, Sprite icon) : base(statType, upgradeStep, maxLevel, description, icon)
        {
        }

        protected override void ApplyToTarget(IHeroProvider heroProvider)
        {
            base.ApplyToTarget(heroProvider);
            heroProvider.Health.Heal(heroProvider.Health.MaxHealth);
        }
    }
}
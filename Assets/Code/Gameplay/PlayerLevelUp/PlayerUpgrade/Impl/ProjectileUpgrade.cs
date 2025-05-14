using Code.Gameplay.Characters.Heroes.Services;
using Code.Gameplay.UnitStats;
using UnityEngine;

namespace Code.Infrastructure.Impl
{
    public class ProjectileUpgrade : PlayerUpgrade
    {
        public ProjectileUpgrade(int maxLevel, string description, Sprite icon) : base(maxLevel, description, icon)
        {
            
        }
        
        public override void Remove(IHeroProvider heroProvider)
        {
            throw new System.NotImplementedException();
        }

        protected override void ApplyToTarget(IHeroProvider heroProvider)
        {
            throw new System.NotImplementedException();
        }
    }
}
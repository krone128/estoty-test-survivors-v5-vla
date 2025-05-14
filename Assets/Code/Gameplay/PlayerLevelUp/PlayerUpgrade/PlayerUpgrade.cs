using Code.Gameplay.Characters.Heroes.Services;
using UnityEngine;

namespace Code.Infrastructure
{
    public abstract class PlayerUpgrade : IPlayerUpgrade
    {
        public int Level { get; private set; }
        public int MaxLevel { get; }
        public string Description { get; protected set; }
        public bool FullyUpgraded => MaxLevel > 0 && Level >= MaxLevel;

        public IPlayerUpgradeViewModel ViewModel { get; private set; } = new PlayerUpgradeViewModel();

        protected PlayerUpgrade(int maxLevel, string description, Sprite icon)
        {
            MaxLevel = maxLevel;
            ViewModel.Icon = icon;
            ViewModel.Description = description;
        }

        public void Apply(IHeroProvider heroProvider)
        {
            if (FullyUpgraded) return;
            ++Level;
            ApplyToTarget(heroProvider);
        }

        public abstract void Remove(IHeroProvider heroProvider);
        protected abstract void ApplyToTarget(IHeroProvider heroProvider);
    }
}
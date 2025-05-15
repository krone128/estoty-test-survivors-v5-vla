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

        public IPlayerUpgradePresenter Presenter { get; } = new PlayerUpgradePresenter();

        protected PlayerUpgrade(int maxLevel, string description, Sprite icon)
        {
            MaxLevel = maxLevel;
            Presenter.Icon = icon;
            Presenter.Description = description;
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
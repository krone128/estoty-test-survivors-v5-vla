using Code.Gameplay.Characters.Heroes.Services;
using Code.Gameplay.PlayerLevelUp.PlayerUpgrade.Services;

namespace Code.Gameplay.PlayerLevelUp.PlayerUpgrade
{
    public interface IPlayerUpgrade
    {
        public int Level { get; }
        public int MaxLevel { get; }
        
        public string Description { get; }
        public bool FullyUpgraded { get; }

        public IPlayerUpgradePresenter Presenter { get; }

        public void Apply(IHeroProvider heroProvider);
        public void Remove(IHeroProvider heroProvider);
        
    }
}
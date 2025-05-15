using Code.Gameplay.PlayerLevelUp.PlayerUpgrade.Config;
using Code.Infrastructure;

namespace Code.Gameplay.PlayerLevelUp.PlayerUpgrade.Services
{
    public interface IPlayerUpgradeFactory
    {
        IPlayerUpgrade CreateUpgrade(PlayerUpgradeConfig config);
    }
}
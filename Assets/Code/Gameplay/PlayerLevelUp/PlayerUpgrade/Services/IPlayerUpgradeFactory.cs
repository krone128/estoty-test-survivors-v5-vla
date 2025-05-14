using Code.Infrastructure.Config;

namespace Code.Infrastructure
{
    public interface IPlayerUpgradeFactory
    {
        IPlayerUpgrade CreateUpgrade(PlayerUpgradeConfig config);
    }
}
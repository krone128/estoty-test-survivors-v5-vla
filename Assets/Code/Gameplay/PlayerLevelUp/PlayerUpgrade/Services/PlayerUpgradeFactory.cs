using Code.Infrastructure.Config;

namespace Code.Infrastructure
{
    public class PlayerUpgradeFactory : IPlayerUpgradeFactory
    {
        public IPlayerUpgrade CreateUpgrade(PlayerUpgradeConfig config)
        {
            return config switch
            {
                PlayerStatUpgradeConfig playerUpgradeConfig =>
                    new StatsPlayerUpgrade(playerUpgradeConfig.StatType,
                    playerUpgradeConfig.UpgradeStep, playerUpgradeConfig.MaxLevel, playerUpgradeConfig.DescriptionFormat, playerUpgradeConfig.Icon),
                
                _ => (IPlayerUpgrade)null
            };
        }
    }
}
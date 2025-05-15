using Code.Infrastructure.Config;
using Code.Infrastructure.PlayerLevelUp.PlayerUpgrade;

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
                    playerUpgradeConfig.UpgradeStep, playerUpgradeConfig.MaxLevel,
                    playerUpgradeConfig.DescriptionFormat, playerUpgradeConfig.Icon),
                
                OrbitalUpgradeConfig orbitalUpgradeConfig =>
                    new OrbitalPlayerUpgrade(orbitalUpgradeConfig.MaxLevel, orbitalUpgradeConfig.OrbitalCount,
                        orbitalUpgradeConfig.OrbitRadius, orbitalUpgradeConfig.RotationSpeed, 
                        orbitalUpgradeConfig.RespawnInterval,
                        orbitalUpgradeConfig.DescriptionFormat, orbitalUpgradeConfig.Icon),
                
                _ => (IPlayerUpgrade)null
            };
        }
    }
}
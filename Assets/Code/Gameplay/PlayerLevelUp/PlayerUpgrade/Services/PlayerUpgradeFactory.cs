using Code.Gameplay.PlayerLevelUp.PlayerUpgrade.Config;
using Code.Infrastructure;
using JetBrains.Annotations;

namespace Code.Gameplay.PlayerLevelUp.PlayerUpgrade.Services
{
    [UsedImplicitly]
    public class PlayerUpgradeFactory : IPlayerUpgradeFactory
    {
        public IPlayerUpgrade CreateUpgrade(PlayerUpgradeConfig config)
        {
            return config switch
            {
                GunStatUpgradeConfig gunStatUpgradeConfig =>
                    new GunStatUpgrade(gunStatUpgradeConfig.StatType, 
                        gunStatUpgradeConfig.UpgradeStep, gunStatUpgradeConfig.MaxLevel,
                        gunStatUpgradeConfig.DescriptionFormat, gunStatUpgradeConfig.Icon),
                
                PlayerStatUpgradeConfig playerStatUpgradeConfig =>
                    new PlayerStatUpgrade(playerStatUpgradeConfig.StatType, 
                        playerStatUpgradeConfig.UpgradeStep, playerStatUpgradeConfig.MaxLevel,
                        playerStatUpgradeConfig.DescriptionFormat, playerStatUpgradeConfig.Icon),
                
                OrbitalUpgradeConfig orbitalUpgradeConfig =>
                    new OrbitalPlayerUpgrade(orbitalUpgradeConfig.MaxLevel, orbitalUpgradeConfig.OrbitalCount,
                        orbitalUpgradeConfig.OrbitRadius, orbitalUpgradeConfig.RotationSpeed, 
                        orbitalUpgradeConfig.RespawnInterval,
                        orbitalUpgradeConfig.DescriptionFormat, orbitalUpgradeConfig.Icon),
                
                _ => null
            };
        }
    }
}
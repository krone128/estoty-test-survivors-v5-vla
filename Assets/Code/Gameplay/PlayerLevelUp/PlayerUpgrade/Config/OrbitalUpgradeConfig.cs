using UnityEngine;

namespace Code.Gameplay.PlayerLevelUp.PlayerUpgrade.Config
{
    [CreateAssetMenu(fileName = "PlayerOrbitalUpgradeConfig", menuName = Constants.GameName + "/Configs/PlayerUpgrade/PlayerOrbitalUpgradeConfig")]
    public class OrbitalUpgradeConfig : PlayerUpgradeConfig
    {
        public int OrbitalCount;
        public int RotationSpeed;
        public int OrbitRadius;
        public int RespawnInterval;
    }
}
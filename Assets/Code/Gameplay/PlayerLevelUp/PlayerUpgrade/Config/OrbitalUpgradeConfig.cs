using Code.Gameplay.UnitStats;
using UnityEngine;

namespace Code.Infrastructure.Config
{
    [CreateAssetMenu(fileName = "PlayerOrbitalUpgradeConfig", menuName = Constants.GameName + "/Configs/PlayerOrbitalUpgradeConfig")]
    public class OrbitalUpgradeConfig : PlayerUpgradeConfig
    {
        public int OrbitalCount;
        public int RotationSpeed;
        public int OrbitRadius;
        public int RespawnInterval;
    }
}
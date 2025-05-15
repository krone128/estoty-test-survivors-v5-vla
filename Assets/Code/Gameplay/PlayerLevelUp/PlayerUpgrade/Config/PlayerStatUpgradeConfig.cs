using Code.Gameplay.UnitStats;
using UnityEngine;

namespace Code.Gameplay.PlayerLevelUp.PlayerUpgrade.Config
{
    [CreateAssetMenu(fileName = "PlayerStatUpgradeConfig", menuName = Constants.GameName + "/Configs/PlayerUpgrade/PlayerStatUpgradeConfig")]
    public class PlayerStatUpgradeConfig : PlayerUpgradeConfig
    {
        public StatType StatType;
        public int UpgradeStep;
    }
}
using Code.Gameplay.UnitStats;
using UnityEngine;

namespace Code.Infrastructure.Config
{
    [CreateAssetMenu(fileName = "PlayerStatUpgradeConfig", menuName = Constants.GameName + "/Configs/PlayerUpgrade/PlayerStatUpgradeConfig")]
    public class PlayerStatUpgradeConfig : PlayerUpgradeConfig
    {
        public StatType StatType;
        public int UpgradeStep;
    }
}
using UnityEngine;

namespace Code.Infrastructure.Config
{
    [CreateAssetMenu(fileName = "PlayerUpgradeServiceConfig", menuName = Constants.GameName + "/Configs/PlayerUpgradeService")]
    public class PlayerUpgradeServiceConfig : ScriptableObject
    {
        public PlayerUpgradeType[] EnabledUpgrades;
        public int UpgradeSelectionRange = 3;
    }
}
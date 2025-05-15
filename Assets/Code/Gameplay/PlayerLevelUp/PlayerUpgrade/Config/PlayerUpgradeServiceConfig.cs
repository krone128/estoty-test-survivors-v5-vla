using System;
using Code.Infrastructure;
using UnityEngine;

namespace Code.Gameplay.PlayerLevelUp.PlayerUpgrade.Config
{
    [CreateAssetMenu(fileName = "PlayerUpgradeServiceConfig", menuName = Constants.GameName + "/Configs/PlayerUpgradeService/PlayerUpgradeServiceConfig")]
    public class PlayerUpgradeServiceConfig : ScriptableObject
    {
        public UpgradeConfigItem[] Upgrades;
        public int UpgradeSelectionRange = 3;
    }

    [Serializable]
    public class UpgradeConfigItem
    {
        public bool Enabled;
        public PlayerUpgradeType Upgrade;
    }
}
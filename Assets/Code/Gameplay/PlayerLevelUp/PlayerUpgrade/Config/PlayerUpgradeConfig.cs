using Code.Infrastructure;
using UnityEngine;

namespace Code.Gameplay.PlayerLevelUp.PlayerUpgrade.Config
{
    public abstract class PlayerUpgradeConfig : ScriptableObject
    {
        public Sprite Icon;
        public PlayerUpgradeType PlayerUpgradeType;
        public int MaxLevel;
        public string DescriptionFormat;
    }
}
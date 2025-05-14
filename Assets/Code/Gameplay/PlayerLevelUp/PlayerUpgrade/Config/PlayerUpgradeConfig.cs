using UnityEngine;

namespace Code.Infrastructure.Config
{
    public abstract class PlayerUpgradeConfig : ScriptableObject
    {
        public Sprite Icon;
        public PlayerUpgradeType PlayerUpgradeType;
        public int MaxLevel;
        public string DescriptionFormat;
    }
}
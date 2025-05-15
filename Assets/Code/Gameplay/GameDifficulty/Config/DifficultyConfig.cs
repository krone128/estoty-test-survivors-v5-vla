using UnityEngine;

namespace Code.Gameplay.GameDifficulty.Config
{
    [CreateAssetMenu(fileName = "DifficultyConfig", menuName = Constants.GameName + "/Configs/Difficulty")]
    public class DifficultyConfig : ScriptableObject
    {
        public float GameDifficultyUpdateInterval = 30;
        public float EnemyHealthStep = 5;
        public float EnemyDamageStep = 5;
    }
}
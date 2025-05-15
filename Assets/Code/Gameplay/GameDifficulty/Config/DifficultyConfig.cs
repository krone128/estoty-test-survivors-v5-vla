using System;
using UnityEngine;

namespace Code.Infrastructure
{
    [CreateAssetMenu(fileName = "DifficultyConfig", menuName = Constants.GameName + "/Configs/Difficulty")]
    public class DifficultyConfig : ScriptableObject
    {
        public float GameDifficultyUpdateInterval = 30;
        public float EnemyDifficultyHealthStep = 5;
        public float EnemyDifficultyDamageStep = 5;
    }
}
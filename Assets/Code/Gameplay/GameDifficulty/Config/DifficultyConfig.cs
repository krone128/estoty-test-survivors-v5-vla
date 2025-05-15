using System;
using UnityEngine;

namespace Code.Infrastructure
{
    [CreateAssetMenu(fileName = "DifficultyConfig", menuName = Constants.GameName + "/Configs/Difficulty")]
    public class DifficultyConfig : ScriptableObject
    {
        public float GameDifficultyUpdateInterval = 30;
        public float EnemyHealthStep = 5;
        public float EnemyDamageStep = 5;
    }
}
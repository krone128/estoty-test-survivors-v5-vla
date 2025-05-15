using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Code.Gameplay.Characters.Enemies.Configs
{
    [CreateAssetMenu(fileName = "SpawnerConfig", menuName = Constants.GameName + "/Configs/Enemy/SpawnerConfig")]
    public class EnemySpawnerConfig : ScriptableObject
    {
        public float SpawnInterval = 2f;
        public float SpawnDistanceGap = 0.5f;
        
        [SerializeField] private SpawnerConfigItem[] _spawnConfigs;
        
        public SpawnerConfigItem[] SpawnConfigs => _spawnConfigs.OrderBy(config => config.SpawnChance).ToArray();
    }

    [Serializable]
    public class SpawnerConfigItem
    {
        public EnemyId EnemyId;
        [Range(0f, 1f)]
        public float SpawnChance = 1f;
    }
}
using Code.Infrastructure.ConfigsManagement;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure
{
    [UsedImplicitly]
    public class DifficultyService : IDifficultyService, ITickable
    {
        private float _lastDifficultyUpdate;
        private float _elapsedTime;
        
        public float EnemyHealthIncrement { get; private set; }
        public float EnemyDamageIncrement { get; private set; }
        
        private DifficultyConfig _config;

        [Inject]
        private void Construct(IConfigsService configsService)
        {
            _config = configsService.DifficultyConfig;
        }
        
        public void ResetDifficulty()
        {
            EnemyHealthIncrement = 0;
            EnemyDamageIncrement = 0;
        }
        
        public void Tick()
        {
            var updateInterval = _config.GameDifficultyUpdateInterval;
            
            if (_elapsedTime < updateInterval)
            {
                _elapsedTime += Time.deltaTime;
                return;
            }

            _elapsedTime -= updateInterval;
            
            IncrementDifficulty();
        }

        private void IncrementDifficulty()
        {
            Debug.Log("Increment Difficulty");
            EnemyDamageIncrement += _config.EnemyDamageStep;
            EnemyHealthIncrement += _config.EnemyHealthStep;
        }
    }
}
using UnityEngine;

namespace Code.Infrastructure
{
    public class DifficultyService : IDifficultyService
    {
        public float EnemyHealthIncrement { get; private set; }
        public float EnemyDamageIncrement { get; private set; }

        private float _lastDifficultyUpdate;
        private float _elapsedTime;
        
        public void ResetDifficulty()
        {
            EnemyHealthIncrement = 0;
            EnemyDamageIncrement = 0;
        }
        
        public void Tick()
        {
            if (_elapsedTime < GameSessionConfig.GameDifficultyUpdateInterval)
            {
                _elapsedTime += Time.deltaTime;
                return;
            }

            _elapsedTime -= GameSessionConfig.GameDifficultyUpdateInterval;
            
            IncrementDifficulty();
        }

        public void IncrementDifficulty()
        {
            Debug.Log("INCREMENT DIFFICULTY");
            EnemyDamageIncrement += GameSessionConfig.EnemyDifficultyDamageStep;
            EnemyHealthIncrement += GameSessionConfig.EnemyDifficultyHealthStep;
        }
    }
}
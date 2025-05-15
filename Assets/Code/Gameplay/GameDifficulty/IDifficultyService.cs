using Zenject;

namespace Code.Infrastructure
{
    public interface IDifficultyService
    {
        public float EnemyHealthIncrement { get; }
        public float EnemyDamageIncrement { get; }
    }
}
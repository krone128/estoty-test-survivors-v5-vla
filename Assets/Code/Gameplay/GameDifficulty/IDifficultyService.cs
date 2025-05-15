using Zenject;

namespace Code.Infrastructure
{
    public interface IDifficultyService : ITickable
    {
        public float EnemyHealthIncrement { get; }
        public float EnemyDamageIncrement { get; }
    }
}
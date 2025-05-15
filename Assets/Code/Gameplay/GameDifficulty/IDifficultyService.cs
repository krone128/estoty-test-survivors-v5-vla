namespace Code.Gameplay.GameDifficulty
{
    public interface IDifficultyService
    {
        public float EnemyHealthIncrement { get; }
        public float EnemyDamageIncrement { get; }
    }
}
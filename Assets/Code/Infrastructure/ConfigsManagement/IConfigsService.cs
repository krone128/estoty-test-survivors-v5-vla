using Code.Gameplay.Characters.Enemies;
using Code.Gameplay.Characters.Enemies.Configs;
using Code.Gameplay.Characters.Heroes.Configs;
using Code.Gameplay.PickUps;
using Code.Gameplay.PickUps.Configs;
using Code.Infrastructure.Config;

namespace Code.Infrastructure.ConfigsManagement
{
	public interface IConfigsService
	{
		HeroConfig HeroConfig { get; }
		PlayerUpgradeServiceConfig PlayerUpgradeServiceConfig { get; }
		DifficultyConfig DifficultyConfig { get; }
		EnemySpawnerConfig EnemySpawnerConfig { get; }
		void Load();
		EnemyConfig GetEnemyConfig(EnemyId id);
		PickUpConfig GetPickUpConfig(PickUpId id);
		PlayerUpgradeConfig GetPlayerUpgradeConfig(PlayerUpgradeType upgradeType);
	}
}
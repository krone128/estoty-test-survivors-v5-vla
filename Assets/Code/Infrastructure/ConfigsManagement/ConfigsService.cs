using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Characters.Enemies;
using Code.Gameplay.Characters.Enemies.Configs;
using Code.Gameplay.Characters.Heroes.Configs;
using Code.Gameplay.GameDifficulty.Config;
using Code.Gameplay.PickUps;
using Code.Gameplay.PickUps.Configs;
using Code.Gameplay.PlayerLevelUp.PlayerUpgrade;
using Code.Gameplay.PlayerLevelUp.PlayerUpgrade.Config;
using Code.Infrastructure.AssetManagement;

namespace Code.Infrastructure.ConfigsManagement
{
	public class ConfigsService : IConfigsService
	{
		private readonly IAssetsService _assets;

		private Dictionary<EnemyId, EnemyConfig> _enemiesById = new();
		private Dictionary<PickUpId, PickUpConfig> _pickupsById = new();
		private Dictionary<PlayerUpgradeType, PlayerUpgradeConfig> _playerUpgradesById = new();

		public HeroConfig HeroConfig { get; private set; }
		public PlayerUpgradeServiceConfig PlayerUpgradeServiceConfig { get; private set; }
		public DifficultyConfig DifficultyConfig { get; private set; }
		public EnemySpawnerConfig EnemySpawnerConfig { get; set; }

		public ConfigsService(IAssetsService assets)
		{
			_assets = assets;
		}
		
		public void Load()
		{
			LoadEnemySpawnerConfig();
			LoadDifficultyConfig();
			LoadHeroConfig();
			LoadEnemyConfigs();
			LoadPickUpConfigs();
			LoadPlayerUpgradeServiceConfig();
			LoadPLayerUpgradeConfigs();
		}

		private void LoadPickUpConfigs()
		{
			var pickUpConfigs = _assets.LoadAssetsFromResources<PickUpConfig>("Configs/PickUps");
			_pickupsById = pickUpConfigs.ToList().ToDictionary(x => x.Id, x => x);
		}

		private void LoadHeroConfig()
		{
			HeroConfig = _assets.LoadAssetFromResources<HeroConfig>("Configs/HeroConfig");
		}
		
		private void LoadEnemySpawnerConfig()
		{
			EnemySpawnerConfig = _assets.LoadAssetFromResources<EnemySpawnerConfig>("Configs/Enemies/SpawnerConfig");
		}
		
		private void LoadDifficultyConfig()
		{
			DifficultyConfig = _assets.LoadAssetFromResources<DifficultyConfig>("Configs/Difficulty/DifficultyConfig");
		}

		
		private void LoadPlayerUpgradeServiceConfig()
		{
			PlayerUpgradeServiceConfig = _assets.LoadAssetFromResources<PlayerUpgradeServiceConfig>("Configs/PlayerUpgradeService/PlayerUpgradeServiceConfig");
		}

		private void LoadEnemyConfigs()
		{
			var enemyConfigs = _assets.LoadAssetsFromResources<EnemyConfig>("Configs/Enemies");
			_enemiesById = enemyConfigs.ToList().ToDictionary(x => x.Id, x => x);
		}
		
		private void LoadPLayerUpgradeConfigs()
		{
			var upgradeConfigs = _assets.LoadAssetsFromResources<PlayerUpgradeConfig>("Configs/PlayerUpgrade");
			_playerUpgradesById = upgradeConfigs.ToList().ToDictionary(x => x.PlayerUpgradeType, x => x);
		}

		public EnemyConfig GetEnemyConfig(EnemyId id)
		{
			if (_enemiesById.TryGetValue(id, out EnemyConfig enemyConfig))
				return enemyConfig;

			throw new KeyNotFoundException($"Enemy config with id {id} not found");
		}
		
		public PickUpConfig GetPickUpConfig(PickUpId id)
		{
			if (_pickupsById.TryGetValue(id, out PickUpConfig pickUpConfig))
				return pickUpConfig;

			throw new KeyNotFoundException($"PickUp config with id {id} not found");
		}
		
		public PlayerUpgradeConfig GetPlayerUpgradeConfig(PlayerUpgradeType id)
		{
			if (_playerUpgradesById.TryGetValue(id, out PlayerUpgradeConfig config))
				return config;

			throw new KeyNotFoundException($"PlayerUpgrade config with id {id} not found");
		}
	}
}
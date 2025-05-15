using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Characters.Heroes.Services;
using Code.Infrastructure.ConfigsManagement;
using Code.Infrastructure.UIManagement;
using Code.UI;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure
{
    public class PlayerUpgradeManager : MonoBehaviour
    {
        private int _upgradeSelectionRange;
        
        private IPlayerUpgradeFactory _playerUpgradeFactory;
        private IHeroProvider _heroProvider;
        private IUiService _uiService;
        private IConfigsService _configsService;
        
        private readonly IList<IPlayerUpgrade> _upgrades = new List<IPlayerUpgrade>();

        [Inject]
        private void Construct(IPlayerUpgradeFactory playerUpgradeFactory, IHeroProvider heroProvider, IUiService uiService, IConfigsService configsService)
        {
            _playerUpgradeFactory = playerUpgradeFactory;
            _heroProvider = heroProvider;
            _uiService = uiService;
            _configsService = configsService;

            var config = _configsService.PlayerUpgradeServiceConfig;
            _upgradeSelectionRange = config.UpgradeSelectionRange;

            foreach (var upgradeType in config.Upgrades)
            {
                if (!upgradeType.Enabled) continue;
                
                var upgradeConfig = _configsService.GetPlayerUpgradeConfig(upgradeType.Upgrade);
                var upgrade = _playerUpgradeFactory.CreateUpgrade(upgradeConfig);
                upgrade.Presenter.OnSelected += Apply;
                _upgrades.Add(upgrade);
                
                continue;

                void Apply()
                {
                    ApplyPlayerUpgrade(upgrade);
                }
            }

            _heroProvider.Experience.OnLevelUp += StartLevelUp;
        }

        private void StartLevelUp(int playerLevel)
        {
            if(_upgrades.All(item => item.FullyUpgraded)) return;
            
            Time.timeScale = 0;
            
            var levelUpWindow = _uiService.OpenWindow<LevelUpWindow>();
            levelUpWindow.SetupItems(GetPlayerUpgradeSelection());
            _uiService.OpenWindow<LevelUpWindow>();
        }

        private IEnumerable<IPlayerUpgradePresenter> GetPlayerUpgradeSelection()
        {
            var hashSet = new HashSet<IPlayerUpgrade>();

            var selectionRange = Mathf.Min(_upgradeSelectionRange, _upgrades.Count(upgrade => !upgrade.FullyUpgraded));
            
            do
            {
                var rand = Random.Range(0, _upgrades.Count);
                var upgrade = _upgrades[rand];
                
                if (hashSet.Contains(upgrade) 
                   || upgrade.FullyUpgraded) continue;
                
                hashSet.Add(upgrade);
            } 
            while (hashSet.Count < selectionRange);
            
            return hashSet.Select(item => item.Presenter);
        }

        private void ApplyPlayerUpgrade(IPlayerUpgrade playerUpgrade)
        {
            _uiService.CloseWindow<LevelUpWindow>();
            playerUpgrade.Apply(_heroProvider);
            CompleteLevelUp();
        }

        private void CompleteLevelUp()
        {
            Time.timeScale = 1;
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Code.Gameplay.Characters.Heroes.Services;
using Code.Infrastructure.ConfigsManagement;
using Code.Infrastructure.UIManagement;
using Code.UI;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure
{
    [UsedImplicitly]
    public class PlayerUpgradeService : IPlayerUpgradeService
    {
        private int _upgradeSelectionRange;
        
        [Inject] private IPlayerUpgradeFactory _playerUpgradeFactory;
        [Inject] private IHeroProvider _heroProvider;
        [Inject] private IUiService _uiService;
        [Inject] private IConfigsService _configsService;

        
        private readonly IList<IPlayerUpgrade> _upgrades = new List<IPlayerUpgrade>();
        
        [Inject]
        private void Construct()
        {
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
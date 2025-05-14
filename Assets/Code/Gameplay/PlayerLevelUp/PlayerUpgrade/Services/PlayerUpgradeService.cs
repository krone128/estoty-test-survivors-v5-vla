using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Characters.Heroes.Services;
using Code.Infrastructure.ConfigsManagement;
using Code.Infrastructure.UIManagement;
using Code.UI;
using JetBrains.Annotations;
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

            foreach (var upgradeType in config.EnabledUpgrades)
            {
                var upgradeConfig = _configsService.GetPlayerUpgradeConfig(upgradeType);
                var upgrade = _playerUpgradeFactory.CreateUpgrade(upgradeConfig);
                upgrade.ViewModel.OnSelected += Apply;
                _upgrades.Add(upgrade);
                
                continue;

                void Apply() => ApplyPlayerUpgrade(upgrade);
            }

            _heroProvider.OnLevelUp += StartLevelUp;
        }

        private void StartLevelUp()
        {
            Time.timeScale = 0;
            
            var levelUpWindow = _uiService.OpenWindow<LevelUpWindow>();
            levelUpWindow.SetupItems(GetPlayerUpgradeSelection());
            _uiService.OpenWindow<LevelUpWindow>();
        }

        public IEnumerable<IPlayerUpgradeViewModel> GetPlayerUpgradeSelection()
        {
            var hashSet = new HashSet<IPlayerUpgrade>();

            do
            {
                var rand = Random.Range(0, _upgrades.Count);
                var upgrade = _upgrades[rand];
                
                if (hashSet.Contains(upgrade) 
                   || upgrade.FullyUpgraded) continue;
                
                hashSet.Add(upgrade);
            } 
            while (hashSet.Count < _upgradeSelectionRange);
            
            return hashSet.Select(item => item.ViewModel);
        }

        public void ApplyPlayerUpgrade(IPlayerUpgrade playerUpgrade)
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
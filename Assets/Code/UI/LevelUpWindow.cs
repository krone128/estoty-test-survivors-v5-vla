using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.PlayerLevelUp.PlayerUpgrade;
using Code.Gameplay.PlayerLevelUp.PlayerUpgrade.Services;
using Code.Infrastructure;
using Code.Infrastructure.UIManagement;
using UnityEngine;

namespace Code.UI
{
    public class LevelUpWindow : WindowBase
    {
        [SerializeField] private PlayerUpgradeLitsItem _cardPrefab;
        
        public override bool IsUserCanClose { get; }
        public PlayerUpgradeLitsItem[] _selectionItems;

        public void SetupItems(IEnumerable<IPlayerUpgradePresenter> getPlayerUpgradeSelection)
        {
            foreach (var item in _selectionItems)
            {
                item.gameObject.SetActive(false);
            }
            
            foreach (var pair in getPlayerUpgradeSelection.Zip(_selectionItems, 
                         (model, item) => new { model, item }))
            {
                pair.item.Initialize(pair.model);
                pair.item.gameObject.SetActive(true);
            }
        }
    }
}
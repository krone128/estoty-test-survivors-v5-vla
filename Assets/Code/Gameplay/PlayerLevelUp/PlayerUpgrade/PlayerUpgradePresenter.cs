using System;
using UnityEngine;

namespace Code.Gameplay.PlayerLevelUp.PlayerUpgrade
{
    public class PlayerUpgradePresenter : IPlayerUpgradePresenter
    {
        public event Action OnSelected;
        
        public Sprite Icon { get; set;  }
        public string Description { get; set; }

        public void Select() => OnSelected?.Invoke();
    }
}
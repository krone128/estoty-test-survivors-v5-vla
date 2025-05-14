using System;
using UnityEngine;

namespace Code.Infrastructure
{
    public class PlayerUpgradeViewModel : IPlayerUpgradeViewModel
    {
        public event Action OnSelected;
        
        public Sprite Icon { get; set;  }
        public string Description { get; set; }

        public void Select()
        {
            OnSelected?.Invoke();
        }
    }
}
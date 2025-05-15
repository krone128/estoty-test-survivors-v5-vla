using System;
using UnityEngine;

namespace Code.Infrastructure
{
    public interface IPlayerUpgradePresenter
    {
        public event Action OnSelected;
        
        public Sprite Icon { get; set; }
        public string Description { get; set; }

        public void Select();
    }
}
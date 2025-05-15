using Code.Infrastructure;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI
{
    public class PlayerUpgradeLitsItem : MonoBehaviour
    {
        [SerializeField] private Text _descriptionText;
        [SerializeField] private Image _image;
        [SerializeField] private Button _button;

        private IPlayerUpgradeViewModel _model;

        private void Awake()
        {
            _button.onClick.AddListener(OnSelected);
        }

        private void OnSelected()
        {
            _model?.Select();
        }

        public void Initialize(IPlayerUpgradeViewModel model)
        {
            _model = model;
            
            _descriptionText.text = _model.Description;
            _image.sprite = _model.Icon;
        }
    }
}
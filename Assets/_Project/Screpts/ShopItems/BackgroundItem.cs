using _Project.Configs;
using TMPro;
using UnityEngine;

namespace _Project.Screpts.ShopItems
{
    public class BackgroundItem : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private int _priceValue;
        [SerializeField] private BackgroundConfig _backgroundConfig;
        [SerializeField] private int _itemIndex;
        [SerializeField] private PlayerWallet _playerWallet;
        [SerializeField] private Background _background;

        ShopItem _shopItem;

        private void Awake()
        {
            _backgroundConfig.InitItems();
            _shopItem = _backgroundConfig.GetItem(_itemIndex);
            if (_shopItem.Unlok)
            {
                _text.text = "USE";
            }
            else
            {
                _text.text = $"{_priceValue}";
            }
        }

        public void UnlockItem()
        {
            if (_shopItem.Unlok)
            {
                _background.SetBackground(_shopItem.Sprite);
                _backgroundConfig.SetPlayerBackground(_itemIndex);
                return;
            }

            if (_playerWallet.Value >= _priceValue)
            {
                _text.text = "USE";
                _playerWallet.SalleValue(_priceValue);
                _backgroundConfig.UnlockItem(_itemIndex);
                _backgroundConfig.SetPlayerBackground(_itemIndex);
                _background.SetBackground(_shopItem.Sprite);
            }
        }
    }
}
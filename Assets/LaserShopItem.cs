using _Project.Configs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LaserShopItem : MonoBehaviour
{
    [SerializeField] private LaserConfig _config;
    [SerializeField] private int _id;
    [SerializeField] private int _price;
    [SerializeField] private PlayerWallet _playerWallet;
    [SerializeField] private TextMeshProUGUI _priceText;

    private Button _button;
    private string _use = "USE";
    private ShopLaserItem _shopLaserItem;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _shopLaserItem = _config.GetLaserShopItem(_id);
        if (_shopLaserItem.IsUnlocked)
        {
            _priceText.text = _use;
        }
        else
        {
            _priceText.text = _price.ToString();
        }
    }

    private void OnEnable() => _button.onClick.AddListener(BuyItem);


    public void BuyItem()
    {
        if (_shopLaserItem.IsUnlocked)
        {
            _config.SetColor(_id);
            return;
        }

        if (_playerWallet.Value >= _price)
        {
            _shopLaserItem.Unlock();
            _config.UnlockItem(_id);
            _playerWallet.SalleValue(_price);
            _priceText.text = _use;
            _config.SetColor(_id);
        }
    }

    private void OnDisable() => _button.onClick.RemoveListener(BuyItem);
}
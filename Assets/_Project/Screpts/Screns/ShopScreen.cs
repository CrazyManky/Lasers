using System;
using _Project.Configs;
using _Project.Screpts.ShopItems;
using UnityEngine;

namespace _Project.Screpts.Screns
{
    public class ShopScreen : BaseScreen
    {
        [SerializeField] private PlayerWallet _playerWallet;
        [SerializeField] private ScorePlayer _scorePlayer;

        public void Update() => _scorePlayer.SetScore(_playerWallet.Value);
        
        public void ShowMenuScreen()
        {
            Dialog.ShowMenuScreen();
        }
    }
}
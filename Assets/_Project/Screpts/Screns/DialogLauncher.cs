using _Project.Screpts.Services;
using _Project.Sound;
using Services;
using UnityEngine;

namespace _Project.Screpts.Screns
{
    public class DialogLauncher : MonoBehaviour, IService
    {
        [SerializeField] private MenuScreen _menuScreen;
        [SerializeField] private SettingsScreen _settingsScreen;
        [SerializeField] private ShopScreen _shopScreen;
        [SerializeField] private LevelScreen _levelScreen;
        [SerializeField] private GamePlayScreen _gameScreen;
        [SerializeField] private AudioManager _audioManager;


        private BaseScreen _activeScreen;


        private void Awake()
        {
            ServiceLocator.Init();
            ServiceLocator.Instance.AddService(this);
            ServiceLocator.Instance.AddService(_audioManager);
        }

        private void Start() => ShowMenuScreen();

        public void ShowMenuScreen()
        {
            _audioManager.PlayMenu();
            ShowScreen(_menuScreen);
        }

        public void ShowSettingsScreen() => ShowScreen(_settingsScreen);
        public void ShowShopScreen() => ShowScreen(_shopScreen);
        public void ShowLevelScreen() => ShowScreen(_levelScreen);

        public void ShowGameScreen()
        {
            _audioManager.PlayButtonClick();
            _audioManager.PlayGame();
            ShowScreen(_gameScreen);
        }

        private void ShowScreen(BaseScreen screen)
        {
            _activeScreen?.Сlose();
            var instanceScreen = Instantiate(screen, transform);
            instanceScreen.Init();
            _activeScreen = instanceScreen;
        }
    }
}
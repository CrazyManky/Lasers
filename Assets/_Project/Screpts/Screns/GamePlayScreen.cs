using _Project.Configs;
using _Project.Screpts.GamePlay;
using TMPro;
using UnityEngine;

namespace _Project.Screpts.Screns
{
    public class GamePlayScreen : BaseScreen
    {
        [SerializeField] private LevelsConfig _levelsConfig;
        [SerializeField] private LevelComplitedScreen _levelWinPrefabScreen;
        [SerializeField] private TextMeshProUGUI _levelIndexText;
        [SerializeField] private PlayerWallet _playerWallet;
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private Transform _transformLevel;

        private Level _levelInstance;
        private LevelData _levelData;
        private LevelComplitedScreen _levelComplitedInstance;

        public override void Init()
        {
            base.Init();
            _levelData = _levelsConfig.GetLevelData(_levelsConfig.LevelIndex);
            _levelInstance = Instantiate(_levelData.Level);
            _levelInstance.Battary.OnValueMax += LevelComplete;
            _levelInstance.transform.position = _transformLevel.position;
            _levelIndexText.text = $"Level {_levelsConfig.LevelIndex + 1}";
            _scoreText.text = $"{_playerWallet.Value}";
        }

        public void LevelComplete()
        {
            _levelComplitedInstance = Instantiate(_levelWinPrefabScreen, transform);
            _levelComplitedInstance.Init();
            Destroy(_levelInstance.gameObject);
        }


        public void Restart()
        {
            if (_levelInstance != null)
            {
                var newInstance = Instantiate(_levelData.Level);
                _levelInstance.Battary.OnValueMax -= LevelComplete;
                Destroy(_levelInstance.gameObject);
                _levelInstance = newInstance;
                _levelInstance.Battary.OnValueMax += LevelComplete;
                _levelInstance.transform.position = _transformLevel.position;
            }
        }

        public void ShowMenuScreen()
        {
            Dialog.ShowMenuScreen();
            Destroy(_levelInstance.gameObject);
        }
    }
}
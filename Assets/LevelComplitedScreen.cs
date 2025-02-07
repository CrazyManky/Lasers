using _Project.Configs;
using _Project.Screpts.Screns;
using _Project.Sound;
using Services;
using UnityEngine;

public class LevelComplitedScreen : MonoBehaviour
{
    [SerializeField] private LevelsConfig _levelsConfig;
    [SerializeField] private PlayerWallet _playerWallet;

    private DialogLauncher _dialogLauncher;
    private AudioManager _audioManager;

    public void Init()
    {
        _dialogLauncher = ServiceLocator.Instance.GetService<DialogLauncher>();
        _audioManager = ServiceLocator.Instance.GetService<AudioManager>();
    }

    public void ShowMenuScreen()
    {
        _dialogLauncher.ShowMenuScreen();
        Destroy(gameObject);
    }

    public void RestartLevel()
    {
        _dialogLauncher.ShowGameScreen();
        Destroy(gameObject);
    }

    public void LoadNextLevel()
    {
        _levelsConfig.LevelComplete(_levelsConfig.LevelIndex);
        _dialogLauncher.ShowGameScreen();
        _playerWallet.SetValue(500);
        Destroy(gameObject);
    }
}
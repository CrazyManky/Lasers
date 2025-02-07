using _Project.Configs;
using _Project.Screpts.Services;
using UnityEngine;

namespace _Project.Sound
{
    public class AudioManager : MonoBehaviour, IService
    {
        [SerializeField] private SoundConfig _soundConfig;
        [SerializeField] private AudioSource _buttonClickListener;
        [SerializeField] private AudioSource _gameSound;
        [SerializeField] private AudioSource _menuMusic;

        public void PlayButtonClick()
        {
            _buttonClickListener.Play();
        }

        public void PlayGame()
        {
            _gameSound.Play();
        }

        public void PlayMenu()
        {
            _menuMusic.Play();
        }

        private void Update()
        {
            _soundConfig.GetSaveValue();
            if (!_soundConfig.SoundActive)
            {
                _buttonClickListener.volume = 0f;
                _gameSound.volume = 0f;
                _menuMusic.volume = 0f;
            }
            else
            {
                _buttonClickListener.volume = 0.1f;
                _gameSound.volume = 0.1f;
                _menuMusic.volume = 0.1f;
            }
        }
    }
}
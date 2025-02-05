using UnityEngine;

namespace _Project.Screpts.Screns
{
    public class SettingsScreen : BaseScreen
    {
       //[SerializeField] private SoundConfig _audioManager;
        [SerializeField] private PrivacyPolicyScreen _privacyPolicyScreen;

        public void DisableSound()
        {
            // AudioManager.PlayButtonClick();
            // _audioManager.SetVolume(false);
        }

        public void ShopPrivacyPolicy()
        {
           // AudioManager.PlayButtonClick();
            Instantiate(_privacyPolicyScreen, transform);
        }

        public void EnableSound()
        {
            // AudioManager.PlayButtonClick();
            // _audioManager.SetVolume(true);
        }

        public void BackToMenu()
        {
           // AudioManager.PlayButtonClick();
            Dialog.ShowMenuScreen();
        }
    }
}
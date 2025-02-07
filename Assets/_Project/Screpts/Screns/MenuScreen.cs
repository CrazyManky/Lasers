namespace _Project.Screpts.Screns
{
    public class MenuScreen : BaseScreen
    {
        public void ShowSettingsScreen()
        {
            AudioManager.PlayButtonClick();
            Dialog.ShowSettingsScreen();
        }

        public void ShowShopScreen()
        {
            AudioManager.PlayButtonClick();
            Dialog.ShowShopScreen();
        }

        public void ShowGameScreen()
        {
            AudioManager.PlayButtonClick();
            Dialog.ShowLevelScreen();
        }
    }
}
using System.Collections.Generic;
using _Project.Configs;
using _Project.Screpts.Screns;
using UnityEngine;
using UnityEngine.UI;

public class LevelScreen : BaseScreen
{
    [SerializeField] private List<Button> _buttons;
    [SerializeField] private LevelsConfig _levelsConfig;
    [SerializeField] private Sprite _levelComplete;
    [SerializeField] private Sprite _levelInactive;


    public override void Init()
    {
        _levelsConfig.InitializeLevels();
        base.Init();
        for (int i = 0; i < _buttons.Count; i++)
        {
            var dataLevel = _levelsConfig.GetLevelData(i);
            if (dataLevel.IsCompleted)
                _buttons[i].image.sprite = _levelComplete;
            else
                _buttons[i].image.sprite = _levelInactive;
        }
    }

    public void ShowGamePlayScreen(int levelIndex)
    {
        _levelsConfig.SelectLevel(levelIndex);
        Dialog.ShowGameScreen();
    }

    public void ShowMenuScreen()
    {
        Dialog.ShowMenuScreen();
    }

    public override void Сlose()
    {
        foreach (var item in _buttons)
        {
            item.onClick.RemoveAllListeners();
        }

        base.Сlose();
    }
}
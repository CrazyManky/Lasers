using System;
using System.Collections.Generic;
using _Project.Screpts.GamePlay;
using UnityEngine;
using Random = System.Random;

namespace _Project.Configs
{
    [CreateAssetMenu(fileName = "LevelsConfig", menuName = "Configs/LevelsConfig")]
    public class LevelsConfig : ScriptableObject
    {
        [SerializeField] private List<LevelData> _levels;

        public int LevelIndex;
        public LevelData CurrentLevel;

        public void InitializeLevels()
        {
            _levels.ForEach((item) => { item.LoadLevelData(); });
        }

        public LevelData GetLevelData(int itemIndex)
        {
            if (itemIndex > _levels.Count)
            {
                CurrentLevel = _levels[new Random().Next(0, _levels.Count)];
                return _levels[new Random().Next(0, _levels.Count)];
            }

            CurrentLevel = _levels[itemIndex];
            return _levels[itemIndex];
        }

        public void LevelComplete(int index)
        {
            _levels[index].CompleteLevel();
            LevelIndex++;
        }

        public void SelectLevel(int levelIndex)
        {
            LevelIndex = levelIndex;
            CurrentLevel = _levels[LevelIndex];
        }
    }


    [Serializable]
    public struct LevelData
    {
        public Level Level;
        [SerializeField] private string _levelIndex;
        [SerializeField] private bool isCompleted;

        public bool IsCompleted => isCompleted;

        public void LoadLevelData()
        {
            var value = PlayerPrefs.GetInt(_levelIndex, 0);
            if (value == 0)
            {
                isCompleted = false;
            }
            else
            {
                isCompleted = true;
            }
        }

        public void CompleteLevel()
        {
            PlayerPrefs.SetInt(_levelIndex, 1);
            isCompleted = true;
        }
    }
}
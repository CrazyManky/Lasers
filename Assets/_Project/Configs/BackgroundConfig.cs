using System;
using UnityEngine;

namespace _Project.Configs
{
    [CreateAssetMenu(fileName = "BackgroundConfig", menuName = "Configs/BackgroundConfig")]
    public class BackgroundConfig : ScriptableObject
    {
        [SerializeField] private ShopItem[] backgroundSprites;

        private const string _backgroundKey = "Background";

        public Sprite GetActiveSprite()
        {
            var shopItem = backgroundSprites[PlayerPrefs.GetInt(_backgroundKey, 0)];
            return shopItem.Sprite;
        }

        public void InitItems()
        {
            foreach (var ShopItem in backgroundSprites)
            {
                ShopItem.Init();
            }
        }

        public ShopItem GetItem(int itemIndex)
        {
            return backgroundSprites[itemIndex];
        }

        public void SetPlayerBackground(int index)
        {
            PlayerPrefs.SetInt(_backgroundKey, index);
        }

        public void UnlockItem(int index)
        {
            backgroundSprites[index].Unlock();
        }
    }


    [Serializable]
    public struct ShopItem
    {
        public int Id;
        public Sprite Sprite;
        public string Key;
        public bool Unlok;

        public void Init()
        {
            var value = PlayerPrefs.GetInt(Key, 0);
            if (value == 0)
            {
                Unlok = false;
            }
            else
            {
                Unlok = true;
            }
        }

        public void Unlock()
        {
            Unlok = true;
            PlayerPrefs.SetInt(Key, 1);
        }
    }
}
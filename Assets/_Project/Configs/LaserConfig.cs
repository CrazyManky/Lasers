using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Configs
{
    [CreateAssetMenu(fileName = "LaserConfig", menuName = "Configs/LaserConfig")]
    public class LaserConfig : ScriptableObject
    {
        [SerializeField] private Material _laserMatertial;
        [SerializeField] private List<ShopLaserItem> _laserColors;

        private Material _defaultLaserMaterial;

        public void UnlockItem(int index)
        {
            _laserColors[index].Unlock();
        }

        public ShopLaserItem GetLaserShopItem(int index)
        {
            return _laserColors[index];
        }

        public Material GetDefaultLaserMaterial()
        {
            if (_defaultLaserMaterial == null)
            {
                _defaultLaserMaterial = _laserMatertial;
            }

            return _defaultLaserMaterial;
        }

        public void SetColor(int colorIndex)
        {
            _defaultLaserMaterial = _laserColors[colorIndex].Color;
        }
    }


    [Serializable]
    public struct ShopLaserItem
    {
        public Material Color;
        public bool IsUnlocked;

        public void Unlock()
        {
            IsUnlocked = true;
        }
    }
}
using System;
using UnityEngine;

namespace _Project.Configs
{
    [CreateAssetMenu(fileName = "PlayerWallet", menuName = "Configs/PlayerWallet")]
    public class PlayerWallet : ScriptableObject
    {
        [SerializeField] private int _value;

        public int Value => _value;

        public void Awake()
        {
            _value = PlayerPrefs.GetInt("PlayerWallet", 0);
        }

        public void SetValue(int value)
        {
            _value += value;
            PlayerPrefs.SetInt("PlayerWallet", value);
        }

        public void SalleValue(int value)
        {
            _value -= value;
            PlayerPrefs.SetInt("PlayerWallet", value);
        }
    }
}
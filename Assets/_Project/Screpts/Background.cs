using _Project.Configs;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Screpts
{
    public class Background : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private BackgroundConfig _backgroundConfig;

        private void Awake()
        {
            _image.sprite = _backgroundConfig.GetActiveSprite();
        }

        public void SetBackground(Sprite sprite)
        {
            _image.sprite = sprite;
        }
    }
}
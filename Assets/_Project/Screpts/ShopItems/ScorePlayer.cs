using TMPro;
using UnityEngine;

namespace _Project.Screpts.ShopItems
{
    public class ScorePlayer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textPlayerScore;

        public void SetScore(int score)
        {
            _textPlayerScore.text = score.ToString();
        }
    }
}

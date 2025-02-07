using UnityEngine;

namespace _Project.Screpts.GamePlay
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private Battary _battary;

        public Battary Battary => _battary;
    }
}
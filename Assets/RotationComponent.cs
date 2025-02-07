using DG.Tweening;
using UnityEngine;

public class RotationComponent : MonoBehaviour
{
    [SerializeField] private float _stepRotation;

    private bool _iInteractive = true;

    public bool IInteractive => _iInteractive;

    public void Rotate()
    {
        if (_iInteractive)
        {
            _iInteractive = false;
            transform.DORotate(new Vector3(0, 0, transform.eulerAngles.z + _stepRotation), 0.5f).OnComplete(() =>
            {
                _iInteractive = true;
            });
        }
    }
}
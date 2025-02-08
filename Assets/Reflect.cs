using System;
using UnityEngine;


[RequireComponent(typeof(RotationComponent))]
public class Reflect : MonoBehaviour
{
    [SerializeField] private Vector2 reflectionDirection;

    private RotationComponent _rotationComponent;

    private void Awake()
    {
        _rotationComponent = GetComponent<RotationComponent>();
    }

    public bool Interactive => _rotationComponent.IInteractive;
    public Vector2 ReflectionDirection => reflectionDirection;
}
using System;
using System.Collections;
using UnityEditor.Build;
using UnityEngine;

public class Battary : MonoBehaviour
{
    [SerializeField] private Material _material;

    private float _maxValue = 1;
    private float _value;
    public event Action OnValueMax;
    private bool _invoke = false;
    private float _delauMax = 2f;
    private float _delauValue = 0f;

    private void Awake()
    {
        _material.SetFloat("_Fill", 0f);
    }

    public void AddValue(float value)
    {
        _delauValue += value;
        if (_delauValue >= _delauMax)
        {
            _delauValue = 0;
            _value += value;
            _material.SetFloat("_Fill", _value);   
        }

        if (_value >= _maxValue)
        {
            _invoke = true;
            OnValueMax?.Invoke();
        }
    }
}
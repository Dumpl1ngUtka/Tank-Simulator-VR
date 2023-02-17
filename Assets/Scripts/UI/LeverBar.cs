using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeverBar : MonoBehaviour
{
    [SerializeField] private float _maxValue;
    [SerializeField] private float _minValue;
    private Image _bar;

    private void Start()
    {
        _bar = GetComponent<Image>();
        ChangeBar(0);
    }
    public void ChangeBar(int gear)
    {
        float range = _maxValue - _minValue;
        _bar.fillAmount = (gear + 2) / range;
    }
}

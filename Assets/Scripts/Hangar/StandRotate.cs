using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandRotate : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private PlayerInputHangar _inputHangar;
    private void Update()
    {
        transform.localEulerAngles += new Vector3(0, _inputHangar.HorizontalAxisValue, 0) * _speed * Time.deltaTime;
    }
}

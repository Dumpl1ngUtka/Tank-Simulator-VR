using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialRotator : MonoBehaviour
{
    [SerializeField] private PlayerGamepadInput _playerGamepadInput;
    [SerializeField] private int _rotationCoefficient;
    [SerializeField] private string _side;
    private float _rotationDigree => _side == "Left" ? _playerGamepadInput.LeftDialDegree: _playerGamepadInput.RightDialDegree;

    
    private void Update()
    {
        transform.localEulerAngles += new Vector3(0, 0, -_rotationDigree / _rotationCoefficient);
    }
}

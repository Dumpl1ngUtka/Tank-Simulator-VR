using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRotator : MonoBehaviour
{
    [SerializeField] private PlayerGamepadInput _playerGamepadInput;
    [SerializeField] private int _rotationCoefficient;

    private float _rotationDigree => _playerGamepadInput.LeftDialDegree;
    private void Update()
    {
        if (_rotationDigree != 0)
        {
            transform.localEulerAngles += new Vector3(0, _rotationDigree / _rotationCoefficient, 0);
        }
    }
}

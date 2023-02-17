using UnityEngine;

public class MainGunRotator : MonoBehaviour
{
    [SerializeField] private PlayerGamepadInput _playerGamepadInput;
    [SerializeField] private int _angleVerticalAimingDown;
    [SerializeField] private int _angleVerticalAimingUp;
    [SerializeField] private int _rotationCoefficient;
    private float _rotationDigree => _playerGamepadInput.RightDialDegree;
    private void Update()
    {
        float _possibleAngle = transform.localEulerAngles.x;
        if (_possibleAngle > 180)
        {
            _possibleAngle -= 360;
        }
        _possibleAngle += _rotationDigree / _rotationCoefficient;
        if (_possibleAngle < -_angleVerticalAimingDown && _possibleAngle > -_angleVerticalAimingUp) 
            transform.localEulerAngles += new Vector3(_rotationDigree / _rotationCoefficient,0, 0);  
    }
}

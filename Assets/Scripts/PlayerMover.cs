using UnityEngine;


public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Tank _tank;

    private float _rotationSpeed;
    private float _moveGear;
    private Rigidbody _rigidbody;
    private int _leftLeverGear => _tank.LeftLever.Gear;
    private int _rightLeverGear => _tank.RightLever.Gear;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
    }
    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        transform.localEulerAngles += Vector3.up * _tank.MaxRotationSpeed * (_rotationSpeed / 4) * Time.deltaTime;
    }
    private void Move()
    {
        for (int i = 0; i < _tank.WheelTransforms.Count; i++)
        {
            RaycastHit hit;
            Transform wheelTransform = _tank.WheelTransforms[i];
            bool rayDidHit = Physics.Raycast(_tank.WheelTransforms[i].position, -Vector3.up, out hit, _tank.WheelDefaultDistance);
            if (rayDidHit)
            {
                Vector3 springDirection = wheelTransform.up;
                Vector3 wheelWorldVelocity = _rigidbody.GetPointVelocity(wheelTransform.position);
                float offset = _tank.WheelDefaultDistance - hit.distance;
                float velocity = Vector3.Dot(springDirection, wheelWorldVelocity);
                float forse = offset * _tank.SpringStrength - velocity * _tank.SpringDamper;
                _rigidbody.AddForceAtPosition(springDirection * forse, wheelTransform.position);

                Vector3 steeringDirection = wheelTransform.right;
                float steeringVelocity = Vector3.Dot(steeringDirection, wheelWorldVelocity);
                float desiredVelocityChange = -steeringVelocity * _tank.CoefficientOfFriction;
                float desiredAcceleration = desiredVelocityChange / Time.fixedDeltaTime;
                _rigidbody.AddForceAtPosition(steeringDirection * desiredAcceleration, wheelTransform.position);

                Vector3 accelerationDirection = wheelTransform.forward;
                if (_moveGear != 0)
                {
                    _rigidbody.drag = 0;
                    float maxSpeed = _tank.SpeedCurve.Evaluate(_moveGear);
                    float speed = Vector3.Dot(accelerationDirection, wheelWorldVelocity);
                    float speedDifferent = Mathf.Abs(maxSpeed) - Mathf.Abs(speed);
                    float transmissionPower = 2 / _moveGear;
                    _rigidbody.AddForceAtPosition(accelerationDirection * speedDifferent * transmissionPower, wheelTransform.position);
                }
                else
                {
                    float speed = Vector3.Dot(accelerationDirection, _rigidbody.velocity);
                    _rigidbody.AddForceAtPosition(-_rigidbody.velocity, wheelTransform.position);
                    if (Mathf.Abs(speed) < 0.05f)
                    {
                        _rigidbody.drag = 100;
                    }
                }
            }
            else if (_rigidbody.drag == 100)
            {
                _rigidbody.drag = 0;
            }
        }
    }

    private void MoveGearChenger()
    {
        if (_leftLeverGear * _rightLeverGear > 0)
        {
            _moveGear = _leftLeverGear > 0 ? Mathf.Min(_leftLeverGear, _rightLeverGear) : Mathf.Max(_leftLeverGear, _rightLeverGear);
        }
        else
        {
            _moveGear = 0;
        }
    }
    private void RotationSpeedChanger()
    {
        _rotationSpeed = -_rightLeverGear + _leftLeverGear;
    }
    public void GearChanged()
    {
        MoveGearChenger();
        RotationSpeedChanger();
    }
}
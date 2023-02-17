using System.Collections.Generic;
using UnityEngine;

public class PlayerGamepadInput : MonoBehaviour
{
    [SerializeField] private Transform _leftLever;
    [SerializeField] private Transform _rightLever;
    [SerializeField] private MainGunController _gunController;
    [SerializeField] private List<Transform> _cameraPositions;
    private int _cameraPositionNumber = 0;
    private Camera _camera;
    private Vector2 _currentPositionLeft;
    private Vector2 _currentPositionRight;
    private int _maxAngleX = 60;
    private int _maxAngleY = 40;
    private float _cameraSpeed = 5;
    private PlayerInput _playerInput;

    public float LeftDialDegree { get; private set; }
    public float RightDialDegree { get; private set; }

    private void Awake()
    {
        _camera = Camera.main;
        _playerInput = new PlayerInput();

        _playerInput.Player.LeftLeverUp.performed += ctx => InputLever(_leftLever, 15);
        _playerInput.Player.LeftLeverDown.performed += ctx => InputLever(_leftLever, -15);        
        _playerInput.Player.RightLeverUp.performed += ctx => InputLever(_rightLever, 15);
        _playerInput.Player.RightLeverDown.performed += ctx => InputLever(_rightLever, -15);

        _playerInput.Player.Shoot.performed += ctx => Shoot();
        _playerInput.Player.Reloaded.performed += ctx => Reloaded();
        _playerInput.Player.ChangeTypeOfBullet.performed += ctx => ChangeTypeOfBullet();

        _playerInput.Player.LookAtSights.performed += ctx => CameraPositionNumberChanger(1);
        _playerInput.Player.LookOut.performed += ctx => CameraPositionNumberChanger(2);
    }
    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void Update()
    {
        CameraMover();
        DialsRotator();
    }

    public void InputLever(Transform lever, float rotationDegree)
    {
        rotationDegree += lever.transform.localEulerAngles.x;
        if (rotationDegree > 180)
        {
            rotationDegree -= 360;
        }
        if (Mathf.Abs(rotationDegree) <= 35)
        {
            lever.transform.localEulerAngles = new Vector3(rotationDegree, 0, 0);
        }
        lever.GetComponent<LeverGear>().ChangeGear();
    }

    private void CameraPositionNumberChanger(int positionNumber)
    {
        if (positionNumber != _cameraPositionNumber)
        {
            _cameraPositionNumber = positionNumber;
        }
        else
        {
            _cameraPositionNumber = 0;   
        }
    }
    private void CameraMover()
    {
        Vector2 axisValue = _playerInput.Player.Camera.ReadValue<Vector2>();
        Vector2 direction = new Vector2(-axisValue.y * _maxAngleY, axisValue.x * _maxAngleX);
        
        _camera.transform.localRotation = Quaternion.Lerp(_camera.transform.localRotation,Quaternion.Euler(direction),Time.deltaTime * _cameraSpeed);
        if ((_camera.transform.position - _cameraPositions[_cameraPositionNumber].position).magnitude > 0.001f)
        {
            _camera.transform.position = Vector3.MoveTowards(_camera.transform.position, _cameraPositions[_cameraPositionNumber].position, Time.deltaTime);
        }
    }

    private void DialsRotator()
    {
        Vector2 lastButOnePositionLeft = _currentPositionLeft;
        _currentPositionLeft = _playerInput.Player.LeftDial.ReadValue<Vector2>();
        LeftDialDegree = Vector2.SignedAngle(lastButOnePositionLeft, _currentPositionLeft);

        Vector2 lastButOnePositionRight = _currentPositionRight;
        _currentPositionRight = _playerInput.Player.RightDial.ReadValue<Vector2>();
        RightDialDegree = Vector2.SignedAngle(lastButOnePositionRight, _currentPositionRight);
    }

    private void Shoot()
    {
        _gunController.Shoot();
    }
    private void Reloaded()
    {
        StartCoroutine(_gunController.Reloading());
    }    
    private void ChangeTypeOfBullet()
    {
        _gunController.ChangeTypeOfBullet();
    }
}

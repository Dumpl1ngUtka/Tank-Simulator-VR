using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHangar : MonoBehaviour
{
    private int _maxAngleX = 60;
    private int _maxAngleY = 40;
    private Camera _camera;
    private float _cameraSpeed = 5;

    private PlayerInput _playerInput;
    public float VerticalAxisValue { get; private set; }
    public float HorizontalAxisValue { get; private set; }
    private void Start()
    {
        _playerInput = new PlayerInput();
        _playerInput.Hangar.Enable();

        _camera = Camera.main;
    }
    private void OnDestroy()
    {
        _playerInput.Hangar.Enable();
    }
    private void Update()
    {
        VerticalAxisValue = _playerInput.Hangar.VerticalMove.ReadValue<float>();
        HorizontalAxisValue = _playerInput.Hangar.Rotate.ReadValue<float>();
        CameraMover();
    }
    private void CameraMover()
    {
        Vector2 axisValue = _playerInput.Hangar.Camera.ReadValue<Vector2>();
        Vector2 direction = new Vector2(-axisValue.y * _maxAngleY, axisValue.x * _maxAngleX);

        _camera.transform.localRotation = Quaternion.Lerp(_camera.transform.localRotation, Quaternion.Euler(direction), Time.deltaTime * _cameraSpeed);
    }
}

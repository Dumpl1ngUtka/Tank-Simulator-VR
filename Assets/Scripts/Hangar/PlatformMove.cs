using UnityEngine;
using UnityEngine.InputSystem;

public class PlatformMove : MonoBehaviour
{
    [SerializeField] private float _maxHeight;
    [SerializeField] private float _minHeight;
    [SerializeField] private float _speed;
    private PlayerInputHangar _inputHangar;
    private void Start()
    {
        _inputHangar = GetComponent<PlayerInputHangar>();
    }
    private void Update()
    {
        float nextPosition = transform.position.y + _inputHangar.VerticalAxisValue * _speed * Time.deltaTime;
        if (nextPosition < _maxHeight && nextPosition > _minHeight)
            transform.position += new Vector3(0, _inputHangar.VerticalAxisValue, 0) * _speed * Time.deltaTime;   
    }
}

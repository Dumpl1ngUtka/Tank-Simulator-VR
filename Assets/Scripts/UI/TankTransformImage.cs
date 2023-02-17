using UnityEngine;

public class TankTransformImage : MonoBehaviour
{
    [SerializeField] private Transform _turretIcon;
    [SerializeField] private Transform _turret;

    private void Update()
    {
        _turretIcon.localEulerAngles = new Vector3(0, 0, -_turret.localEulerAngles.y);
    }
}

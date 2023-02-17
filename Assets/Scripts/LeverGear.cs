using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverGear : MonoBehaviour
{
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private LeverBar _leverBar;
    private int _gear = 0;

    public int Gear => _gear;

    public void ChangeGear()
    {
        float degree = transform.localEulerAngles.x;
        if (degree > 180)
        {
            degree -= 360;
        }

        if (degree > 18)
        {
            _gear = 2;
        }
        else if (degree > 6)
        {
            _gear = 1;
        }
        else if (degree < -18)
        {
            _gear = -2; 
        }    
        else if (degree < -6)
        {
            _gear = -1;
        }
        else
        {
            _gear = 0;
        }
        _leverBar.ChangeBar(_gear);
        _playerMover.GearChanged();
    }
}

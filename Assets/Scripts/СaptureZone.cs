using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ÑaptureZone : MonoBehaviour
{
    [SerializeField] private float _timeToCapture;
    [SerializeField] private int _pointPerSecond;
    private int _alphaTeamOnBaseCount;
    private int _betaTeamOnBaseCount;
    private float _alphaProgress = 0;
    private float _betaProgress = 0;
    private float _speed;

    public float AlphaProgress => _alphaProgress / 100;
    public float BetaProgress => _betaProgress / 100;

    public int AlphaPoints { get; private set; }
    public int BetaPoints { get; private set; }

    private void Start()
    {
        _speed = 100 / _timeToCapture;
        AlphaPoints = 0;
        BetaPoints = 0;
    }
    private void Update()
    {
        if (_alphaTeamOnBaseCount > 0 && _betaTeamOnBaseCount == 0)
        {
            int teamSpeedBonus = _alphaTeamOnBaseCount;
            if (teamSpeedBonus > 3)
            {
                teamSpeedBonus = 3;
            }

            if (_betaProgress > 0)
            {
                _betaProgress -= _speed * teamSpeedBonus * Time.deltaTime;
            }
            else
            {
                if (_alphaProgress < 100)
                {
                    _alphaProgress += _speed * teamSpeedBonus * Time.deltaTime;
                }
                else
                {
                    _alphaProgress = 100;
                }
            }
        }
        else if (_betaTeamOnBaseCount > 0 && _alphaTeamOnBaseCount == 0)
        {
            int teamSpeedBonus = _betaTeamOnBaseCount;
            if (teamSpeedBonus > 3)
            {
                teamSpeedBonus = 3;
            }

            if (_alphaProgress > 0)
            {
                _alphaProgress -= _speed * teamSpeedBonus * Time.deltaTime;
            }
            else
            {
                if (_alphaProgress < 100)
                {
                    _betaProgress += _speed * teamSpeedBonus * Time.deltaTime;
                }
                else
                {
                    _betaProgress = 100;
                }
            }
        }
        if (_alphaProgress >= 100)
        {
            AlphaPoints = _pointPerSecond;
        }
        if (_betaProgress >= 100)
        {
            BetaPoints = _pointPerSecond;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Alpha>())
            _alphaTeamOnBaseCount++;
        if (other.GetComponent<Beta>())
            _betaTeamOnBaseCount++;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Alpha>())
            _alphaTeamOnBaseCount--;
        if (other.GetComponent<Beta>())
            _betaTeamOnBaseCount--;
    }
}
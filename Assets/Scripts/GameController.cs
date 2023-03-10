using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private List<ŅaptureZone> _captureZones;
    [SerializeField] private int maxPoint;
    private float _alphaTeamPoint = 0;
    private float _betaTeamPoint = 0;

    public float AlphaTeamPoint => _alphaTeamPoint;
    public float BetaTeamPoint => _betaTeamPoint;
    public int MaxPoint => maxPoint;
    private void Update()
    {
        foreach (ŅaptureZone ņaptureZone in _captureZones)
        {
            _alphaTeamPoint += ņaptureZone.AlphaPoints * Time.deltaTime;
            _betaTeamPoint += ņaptureZone.BetaPoints * Time.deltaTime;
        }
        ChechWinner();
    }
    private void ChechWinner()
    {
        if (_alphaTeamPoint >= maxPoint && _alphaTeamPoint >= maxPoint)
        {
            //
        }
        else if (_alphaTeamPoint >= maxPoint)
        {
            //
        }
        else if (_betaTeamPoint >= maxPoint)
        {
            //
        }
    }
}

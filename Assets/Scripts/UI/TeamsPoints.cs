using TMPro;
using UnityEngine;

public class TeamsPoints : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _greenPoints;
    [SerializeField] private TMP_Text _redPoints;
    [SerializeField] private GameController _gameController;
    private bool _isAlphaTeam;
    private string _alphaPointsText => Mathf.Ceil(_gameController.AlphaTeamPoint).ToString();
    private string _betaPointsText => Mathf.Ceil(_gameController.BetaTeamPoint).ToString();

    private void Start()
    {
       _isAlphaTeam = _player.GetComponent<Alpha>();
    }
    private void Update()
    {
        if (_isAlphaTeam)
        {
            _greenPoints.text = _alphaPointsText;
            _redPoints.text = _betaPointsText;
        }
        else
        {
            _greenPoints.text = _betaPointsText;
            _redPoints.text = _alphaPointsText;
        }
    }
}

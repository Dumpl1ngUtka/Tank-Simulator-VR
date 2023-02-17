using UnityEngine;
using UnityEngine.UI;

public class ZoneImageController : MonoBehaviour
{
    [SerializeField] private Image _greenTeamImage;
    [SerializeField] private Image _redTeamImage;
    [SerializeField] private ÑaptureZone _ñaptureZone;
    private Player _player;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
    }
    private void Update()
    {
        Rotation();
        FillImage();
        ChageSize();
    }

    private void Rotation()
    {
        transform.LookAt(_player.transform);
    }

    private void ChageSize()
    {
        int sizeFactor = 300;
        float distanceToPlayer = Vector3.Magnitude(_player.transform.position - transform.position);
        transform.localScale = new Vector3(-1,1,1) * distanceToPlayer / sizeFactor;
    }

    private void FillImage()
    {
        _greenTeamImage.fillAmount = _ñaptureZone.AlphaProgress;
        _redTeamImage.fillAmount = _ñaptureZone.BetaProgress;
    }
}

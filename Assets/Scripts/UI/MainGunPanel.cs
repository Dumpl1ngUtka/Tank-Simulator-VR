using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainGunPanel : MonoBehaviour
{
    [SerializeField] private Image _reloadImage;
    [SerializeField] private List<Image> _bullets;
    [SerializeField] private MainGunController _mainGunController;
    [SerializeField] private Color _reloadImageActiveColor;
    [SerializeField] private Color _reloadImageNotActiveColor;

    private void Start()
    {
        for (int i = 0; i < _mainGunController.TypeOfBullets.Count; i++)
        {
            _bullets[i].sprite = _mainGunController.TypeOfBullets[i].Icon;
            _bullets[i].color = new Vector4(1,1,1,0.5f);
        }
        SetActiveBullet(0);
    }
    public void SetActiveReloadImage(Color color)
    {
        _reloadImage.color = color;
    }
    public void SetActiveBullet(int index)
    {
        for (int i = 0; i < _mainGunController.TypeOfBullets.Count; i++)
        {
            _bullets[i].color = new Vector4(1, 1, 1, 0.5f);
        }
        _bullets[index].color = new Vector4(1, 1, 1, 1);
    }
    

}

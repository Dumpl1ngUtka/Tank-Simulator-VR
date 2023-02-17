using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGunController : MonoBehaviour
{
    [SerializeField] private Transform _bulletSpawnPoint;
    [SerializeField] private List<Bullet> _typeOfBullets;
    [SerializeField] private float _rechargeTime;
    [SerializeField] private MainGunPanel _mainGunPanel;
    [SerializeField] private Rigidbody _playerRigidbody;
    private Bullet _currentBullet;  
    private Bullet _currentTypeOfBullet;
    private int _indexTypeOfBullet = 0;
    private bool _isReloading;
    public List<Bullet> TypeOfBullets => _typeOfBullets;
    public Bullet CurrentBullet => _currentBullet;
    private void Start()
    {
        _currentTypeOfBullet = _typeOfBullets[_indexTypeOfBullet];
        StartCoroutine(Reloading());
        ChangeReloadImageColor();
    }
    public void Shoot()
    {
        if (_currentBullet != null)
        {
            Instantiate(_currentBullet.gameObject, _bulletSpawnPoint.position, _bulletSpawnPoint.rotation);
        }
        _currentBullet = null;
        ChangeReloadImageColor();
    }
    public IEnumerator Reloading()
    {
        if (_currentBullet != _currentTypeOfBullet && !_isReloading)
        {
            _isReloading = true;
            _currentBullet = null;
            float time = _rechargeTime;
            ChangeReloadImageColor();
            while (time > 0)
            {
                time -= Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            SetBullet();
            yield return null;
        }
        else
        {
            yield return null;
        }
    }

    private void SetBullet()
    {
        _currentBullet = _currentTypeOfBullet;

        _isReloading = false;

        ChangeReloadImageColor();
    }

    public void ChangeTypeOfBullet()
    {
        _indexTypeOfBullet++;
        if (_indexTypeOfBullet > _typeOfBullets.Count - 1)
        {
            _indexTypeOfBullet = 0;
        }
        
        _currentTypeOfBullet = _typeOfBullets[_indexTypeOfBullet];
        _mainGunPanel.SetActiveBullet(_indexTypeOfBullet);

        ChangeReloadImageColor();
    }

    private void ChangeReloadImageColor()
    {
        if (_isReloading)
        {
            _mainGunPanel.SetActiveReloadImage(Color.yellow);
        }
        else if (_typeOfBullets[_indexTypeOfBullet] != _currentBullet && _currentBullet != null)
        {
            _mainGunPanel.SetActiveReloadImage(Color.blue);
        }
        else if (_currentBullet != null)
        {
            _mainGunPanel.SetActiveReloadImage(Color.green);
        }
        else
        {
            _mainGunPanel.SetActiveReloadImage(Color.red);
        }
    }
}

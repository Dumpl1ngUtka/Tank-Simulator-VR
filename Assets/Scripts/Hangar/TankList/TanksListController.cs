using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TanksListController : MonoBehaviour
{
    [SerializeField] private List<Tank> _tanks;
    [SerializeField] private Item _prefab;
    [SerializeField] private GameObject _container;
    [SerializeField] private Transform _modelSpawnPoint;
    private PlayerInput _playerInput;
    private int _currentTankIndex = 0;

    public int CurrentTankIndex => _currentTankIndex;
    private void Start()
    {
        _playerInput = new PlayerInput();
        _playerInput.Hangar.Enable();

        _playerInput.Hangar.ChooseLeft.performed += ctx => ChangeTankSelection(-1);
        _playerInput.Hangar.ChooseRight.performed += ctx => ChangeTankSelection(1);

        _playerInput.Hangar.Select.performed += ctx => Select(_currentTankIndex);

        FillContainer();
    }
    private void OnDestroy()
    {
        _playerInput.Hangar.Disable();
    }
    private void FillContainer()
    {
        foreach (var tank in _tanks)
        {
            var item = Instantiate(_prefab, _container.transform);
            item.Inin(tank.Name,tank.Icon);
        }
    }
    private void ChangeTankSelection(int changeIndex)
    {
        int nextIndex = _currentTankIndex + changeIndex;
        if (nextIndex >= 0 && nextIndex < _tanks.Count)
        {
            _currentTankIndex = nextIndex;
        }
    }

    private void Select(int index)
    {
        if (_modelSpawnPoint.childCount != 0)
            Destroy(_modelSpawnPoint.GetChild(0).gameObject);
        Instantiate(_tanks[index].gameObject, _modelSpawnPoint);
    }
}

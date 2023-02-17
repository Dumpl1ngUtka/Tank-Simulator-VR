using UnityEngine;
using UnityEngine.SceneManagement;

public class HangarController : MonoBehaviour
{
    private PlayerInput _playerInput;
    private void Start()
    {
        _playerInput = new PlayerInput();
        _playerInput.Hangar.Enable();

        _playerInput.Hangar.StartBattle.performed += ctx => StartBattle();
    }
    private void OnDestroy()
    {
        _playerInput.Hangar.Disable();
    }
    private void StartBattle()
    {
        SceneManager.LoadScene(1,LoadSceneMode.Single);
    }
}

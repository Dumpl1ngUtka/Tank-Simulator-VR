using UnityEngine;

public class CanDestroy : MonoBehaviour
{
    [SerializeField] private GameObject _defaultModel; 
    [SerializeField] private GameObject _destroyModel;

    private void Awake()
    {
        _defaultModel.SetActive(true);
        _destroyModel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy();
    }
    private void Destroy()
    {
        _defaultModel.SetActive(false);
        _destroyModel.SetActive(true);
        GetComponent<Collider>().enabled = false;
    }
}

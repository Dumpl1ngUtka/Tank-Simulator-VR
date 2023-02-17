using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public abstract class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;
    [SerializeField] private int _armorPenetration;
    [SerializeField] public Sprite Icon;
    [SerializeField] public Transform _rayPoint;
    private Rigidbody _rigidbody;
    private RaycastHit RaycastHit;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = transform.forward * _speed;
    }
    private void OnTriggerEnter(Collider other)
    {
        CheckColliders(other);
    }
    private void CheckColliders(Collider collider)
    {
        if (collider.GetComponent<HitBox>() != null)
        {
            float angleOfEntry = CalculateAngleOfEntry();
            float finalArmorPenetration = _armorPenetration * Mathf.Sin(angleOfEntry);
            collider.GetComponent<HitBox>().Hited(_damage, finalArmorPenetration);
            Destroy(this.gameObject);
        }
        if (collider.GetComponent<CanDestroy>() == null)
        {
            Destroy(this.gameObject);
        }
    }
    private float CalculateAngleOfEntry()
    {
        RaycastHit hit;
        Physics.Raycast(_rayPoint.position, transform.forward,hitInfo: out hit);    
        Debug.Log(Vector3.Angle(transform.forward, hit.normal));
        return Vector3.Angle(transform.forward,hit.normal);
    }
}

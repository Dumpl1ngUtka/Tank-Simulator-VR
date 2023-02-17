using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    [SerializeField] public string Name;
    [SerializeField] public Sprite Icon;
    [SerializeField] public Sprite ClassIcon;

    [Header("Health Settings")]
    [SerializeField] private int Health;
    [Header("Move Settings")]
    [SerializeField] public float MaxRotationSpeed;
    [SerializeField] public List<Transform> WheelTransforms;
    [SerializeField] public float WheelDefaultDistance;
    [SerializeField] public float SpringStrength;
    [SerializeField] public float SpringDamper;
    [SerializeField] public float BrakeFrictionCoefficient;
    [SerializeField] public LeverGear LeftLever;
    [SerializeField] public LeverGear RightLever;
    [SerializeField] public float CoefficientOfFriction;
    [SerializeField] public AnimationCurve SpeedCurve;
    //[Header("Shoot Settings")]

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Destroy(this.gameObject);
        }
        //Debug.Log(Health);
    }
}

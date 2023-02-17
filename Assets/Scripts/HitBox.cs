using UnityEngine;

public class HitBox : MonoBehaviour
{
    [SerializeField] private int _armorThickness;
    [SerializeField] private Tank _tank;
    public void Hited(int damage,float finalArmorPenetration)
    {
        if (finalArmorPenetration > _armorThickness)
        {
            _tank.TakeDamage(damage);
        }
    }
}

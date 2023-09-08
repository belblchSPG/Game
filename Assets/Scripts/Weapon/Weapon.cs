using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected float _weaponDamage;
    [SerializeField] protected string _weaponName;

    public float GetWeaponDamage()
    {
        return _weaponDamage;
    }
}
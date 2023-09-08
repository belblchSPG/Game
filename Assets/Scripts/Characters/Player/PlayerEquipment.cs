using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{
    [SerializeField] private Weapon _equipedWeapon;

    private void Start()
    {
        _equipedWeapon = FindObjectOfType<Weapon>();
    }

    public Weapon GetEquipedWeapon()
    {
        return _equipedWeapon;
    }
}

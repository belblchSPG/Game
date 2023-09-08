using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{

    [SerializeField] private PlayerAttackSystem _attackSystem;
    [SerializeField] private Weapon _weapon;

    [SerializeField] private float weaponLength;
    [SerializeField] private float weaponDamage;
    [SerializeField] private bool _canDealDamage = false;

    void Start()
    {
        _attackSystem = GetComponentInParent<PlayerAttackSystem>();
        _weapon = GetComponentInParent<Weapon>();
    }

    void Update()
    {
        RaycastHit hit;

        int layerMask = 1 << 9;

        if (_attackSystem.IsAttacking() && _attackSystem.CanDealDamage() && Physics.Raycast(transform.position, -transform.up, out hit, weaponLength, layerMask))
        {
            if(hit.transform.TryGetComponent(out EnemyCharacter enemy))
            {
                enemy.TakeDamage(_weapon.GetWeaponDamage());
                _attackSystem.DisableDealDamage();
                Debug.Log("Damage");
            }
            
        }
    }
   
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position - transform.up * weaponLength);
    }

    
}

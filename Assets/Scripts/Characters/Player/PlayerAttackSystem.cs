using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackSystem : MonoBehaviour
{
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private bool _canAttack = true;
    [SerializeField] private bool _isAttacking;
    [SerializeField] private float _attackDuration = 1.2f;
    [SerializeField] private List<GameObject> _enemies;

    [SerializeField] private bool _canDealDamage = false;

    private void Start()
    {
        _playerAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        AttackAnimationControl();
    }

    public void AttackAnimationControl()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && _canAttack)
        {
            StartCoroutine(AttackCooldown());
            _playerAnimator.SetBool("Attacking", _isAttacking);
            return;
        }
        _playerAnimator.SetBool("Attacking", _isAttacking);
    }

    private IEnumerator AttackCooldown()
    {
        _canAttack = false;
        _isAttacking = true;
        yield return new WaitForSeconds(_attackDuration);
        _canAttack = true;
        _isAttacking = false;
    }

    public bool IsAttacking()
    {
        return _isAttacking;
    }

    public void EnableDealDamage()
    {
        _canDealDamage = true;
    }

    public bool CanDealDamage()
    {
        return _canDealDamage;
    }

    public void DisableDealDamage()
    {
        _canDealDamage = false;
    }
}
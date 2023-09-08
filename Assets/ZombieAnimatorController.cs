using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAnimatorController : MonoBehaviour
{
    [SerializeField] private ZombieCharacter _zombieCharacter;
    [SerializeField] private Animator _zombieAnimator;
    [SerializeField] private Animation _animation;

    private void Start()
    {
        _zombieCharacter = GetComponent<ZombieCharacter>();
        _zombieAnimator = GetComponent<Animator>();
        _animation = GetComponent<Animation>();
    }

    private void Update()
    {
        HandleAnimations();
    }

    private void HandleAnimations()
    {
        if(_zombieCharacter.IsDead())
        {
            StartCoroutine(Death());
        }
        if(_zombieCharacter.IsTakingDamage())
        {
            StartCoroutine(TakeDamage());
        }
    }

    private IEnumerator Death()
    {
        _zombieAnimator.SetTrigger("IsDeadTrigger");
        yield return null;
        _zombieAnimator.ResetTrigger("IsDeadTrigger");
    }
    
    private IEnumerator TakeDamage()
    {
        _zombieAnimator.SetTrigger("TakeDamage");
        yield return null;
        _zombieAnimator.ResetTrigger("TakeDamage");
    }
}

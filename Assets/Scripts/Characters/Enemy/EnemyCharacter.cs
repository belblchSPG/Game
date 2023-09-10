using RPG;
using System.Collections;
using UnityEngine;

public class EnemyCharacter : MonoBehaviour, IEnemy
{

    [SerializeField] protected float _health;
    [SerializeField] protected int _experience;
    [SerializeField] protected string _name;
    [SerializeField] private bool _canTakeDamage = true;
    [SerializeField] private bool _isTakingDamage = false;
    [SerializeField] private bool _isDead = false;

    public int ID { get; set; }
    public void TakeDamage(float damage)
    {
        if(_canTakeDamage) 
        {
            _health -= damage;
            StartCoroutine(TakeDamage());
            if (!_isDead && _health <= 0)
            {
                _health = 0;
                _canTakeDamage = false;
                _isDead = true;
                StartCoroutine(Die());
            }
        }
    }


    public bool IsTakingDamage()
    {
        return _isTakingDamage;
    }

    public bool IsDead()
    {
        return _isDead;
    }

    private IEnumerator Die()
    {
        CombatEvent.EnemyDied(this);
        GameManagerContainer.Instance.GetPlayer().GetComponent<PlayerAttributes>().AddExperience(_experience);
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }

    private IEnumerator TakeDamage()
    {
        _isTakingDamage = true;
        yield return new WaitForSeconds(1);
        _isTakingDamage = false;
    }

    void IEnemy.Die()
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage(int amount)
    {
        throw new System.NotImplementedException();
    }

    public string GetEnemyName()
    {
        return _name;
    }
}
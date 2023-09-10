using UnityEngine;
using System.Collections;


public interface IEnemy
{
    int ID { get; set; }

    void Die();
    string GetEnemyName();
    void TakeDamage(float amount);
}
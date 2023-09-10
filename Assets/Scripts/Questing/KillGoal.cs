using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillGoal : Goal
{
    [SerializeField] private int EnemyID;
    [SerializeField] private float _currentAmount;
    [SerializeField] private float _requiredAmount;

    public KillGoal(Quest quest, int enemyID, string description, bool completed, int currentAmount, int requiredAmount)
    {
        this.Quest = quest;
        EnemyID = enemyID;
        _completedStatus = completed;
        _currentAmount = currentAmount; 
        _requiredAmount = requiredAmount;
    }

    public override void Init()
    {
        base.Init();
        CombatEvent.OnEnemyDeath += EnemyDied;
    }

    public void Evaluate()
    {
        Debug.Log(_currentAmount);
        if (_currentAmount >= _requiredAmount)
        {
            Complete();
        }
    }

    private void Complete()
    {
        _completedStatus = true;
        this.Quest.CheckGoals();
        Debug.Log("Completed");
    }

    public void EnemyDied(IEnemy enemy)
    {
        if(enemy.ID == EnemyID) 
        {
            Debug.Log("Detected enemy death: " + enemy.GetEnemyName());
            _currentAmount++;
            Evaluate();
        }
    }
}

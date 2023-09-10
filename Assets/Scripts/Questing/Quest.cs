using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using RPG;

public class Quest : MonoBehaviour
{
    [SerializeField] protected List<Goal> _questGoals = new List<Goal>();
    [SerializeField] protected int _experienceReward;
    [SerializeField] protected bool _completed;

    public void CheckGoals()
    {
        _completed = _questGoals.All(g => g.IsCompleted());
    }

    public void GiveReward()
    {
        Debug.Log("rewarded");
        GameManagerContainer.Instance.GetPlayer().GetComponent<PlayerAttributes>().AddExperience(_experienceReward);
    }

    public bool IsCompleted()
    {
        return _completed;
    }
}
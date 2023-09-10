using System.Collections.Generic;
using UnityEngine;

public class FirstQuest : Quest
{
    void Start()
    {
        _experienceReward = 100;
        _questGoals = new List<Goal>
        {
            new KillGoal(this, 0, "Kill 1 zombie", false, 0, 1),
        };

        _questGoals.ForEach(g => g.Init());
    }
}

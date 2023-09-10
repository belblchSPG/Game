using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : NPC
{
    public bool AssignedQuest;
    public bool Completed;

    public GameObject quests;

    public string questType;
    public Quest quest;

    public override void Interact()
    {
        if (!AssignedQuest && !Completed)
        {
            AssignQuest();
        }

        else if (AssignedQuest && !Completed)
        {
            CheckQuest();
        }
    }

    public void AssignQuest()
    {
        AssignedQuest = true;
        quest = (Quest)quests.AddComponent(System.Type.GetType("FirstQuest"));
    }

    public void CheckQuest()
    {
        if (quest.IsCompleted())
        {
            quest.GiveReward();
            Completed = true;
            AssignedQuest = false;
        }
    }
}

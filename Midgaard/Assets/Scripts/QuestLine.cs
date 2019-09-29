using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class QuestLine : ScriptableObject
{
    public string title;

    public Quest[] quests;
    public int activeQuestIndex;

    public void SetNextQuest()
    {
        if (quests.Length > activeQuestIndex)
        {
            quests[activeQuestIndex].Complete();
            activeQuestIndex++;
            quests[activeQuestIndex].SetActive();
        } else
        {
            // Questline Finished
        }
    }

    public void DubugActiveQuest()
    {
        foreach(Quest q in quests)
        {
            Debug.Log(q);
        }
    }
}

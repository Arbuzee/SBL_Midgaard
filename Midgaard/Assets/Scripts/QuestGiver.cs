﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    public Quest[] quests;
    private int currentQuestIndex;
    
    private void IncreaseQuestIndex()
    {
        currentQuestIndex++;
    }

    public Quest GetQuest()
    {
        return quests[currentQuestIndex];
    }

    public void QuestCompleted()
    {
        
    }
}

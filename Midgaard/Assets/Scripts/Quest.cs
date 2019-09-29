using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Quest : ScriptableObject
{
    public string title;
    public string description;
    public int goldReward;

    public bool isActive;
    public bool isComplete;

    //public QuestGoal questGoal;

    private bool itemInPlace;

    public void SetActive()
    {
        isActive = true;
    }

    public void Complete()
    {
        isActive = false;
        isComplete = true;
    }

    /*public void CheckIfComplete()
    {
        if (questGoal.Equals("Collect"))
        {
            Debug.Log("ya");
        } else if (questGoal.Equals("Talk"))
        {

        } else if (questGoal.Equals("Find"))
        {

        }
    }

    public enum QuestGoal
    {
        Collect,
        Talk,
        Find
    }*/
}

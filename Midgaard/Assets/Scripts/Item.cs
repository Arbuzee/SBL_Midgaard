using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string title;
    public string description;
    public int journalIndex;

    private float timer;
    private bool timerActive;
    public bool itemRead;
    public bool itemCounted;

    public float timeToRead = 5f;

    private void Update()
    {
        if (timerActive)
        {
            timer += Time.deltaTime;
        }
        if (timer > timeToRead)
        {
            itemRead = true;
        }
    }

    public void StartTimer()
    {
        timerActive = true;
    }

    public void EndTimer()
    {
        timerActive = false;
        timer = 0;
    }
}

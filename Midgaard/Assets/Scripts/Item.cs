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

    public float currentAlpha;
    public bool pulse;

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

        if(!itemRead)
        {
            if (currentAlpha <= 0.0f)
            {
                pulse = true;
            }
            else if (currentAlpha >= 0.2f)
            {
                pulse = false;
            }

            if (pulse)
            {
                currentAlpha += Time.deltaTime * 0.2f;
            }
            else
            {
                currentAlpha -= Time.deltaTime * 0.2f;
            }

            Color c = GetComponent<SpriteRenderer>().color;
            GetComponent<SpriteRenderer>().color = new Color(currentAlpha, currentAlpha, currentAlpha, 1);
        } else
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
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

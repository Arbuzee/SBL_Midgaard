using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHold : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerController pCon = other.GetComponent<PlayerController>();
            if (!pCon.isHoldingItem)
            {
                pCon.itemAvailable = true;
                pCon.SetItem(gameObject);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().itemAvailable = false;
        }
    }
}

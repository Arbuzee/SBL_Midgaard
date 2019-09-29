using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPlacedCheck : MonoBehaviour
{
    public string itemTag;
    public bool itemInPlace;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other);
        if (other.CompareTag(itemTag))
        {
            itemInPlace = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(itemTag))
        {
            itemInPlace = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeScript : MonoBehaviour
{
    public void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) 
        {
            other.gameObject.GetComponent<SpriteRenderer>().sortingOrder = -1;
        }
    }

    public void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) 
        {
            other.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
        }
    }
}

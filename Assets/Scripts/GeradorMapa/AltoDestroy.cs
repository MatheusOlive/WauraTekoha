using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltoDestroy : MonoBehaviour
{
    public string Tag;
    public bool Comecou;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == Tag)
        {
            Destroy(gameObject);

        }
    }
}
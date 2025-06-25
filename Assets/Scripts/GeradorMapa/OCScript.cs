using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OCScript : MonoBehaviour
{
    private GameObject Filho;
    public string NomeFilho;
    private void Start()
    {
        Filho = gameObject.transform.GetChild(0).gameObject;
        Filho.SetActive(false);
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "OC")
        {
            Filho.SetActive(true);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    { 
        if (collision.transform.tag == "OC")
        {
            Filho.SetActive(false);
        }
    }
}

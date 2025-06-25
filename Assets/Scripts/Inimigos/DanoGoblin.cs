using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanoGoblin : MonoBehaviour
{    
    public int Dano;
    public GameObject Player;

    private void Start()
    {
        Player = GameObject.FindGameObjectsWithTag("Player")[0];
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Player.GetComponent<Player>().TakeDamage(Dano);
            gameObject.SetActive(false);
        }
    }
}

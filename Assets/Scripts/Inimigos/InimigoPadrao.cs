using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class InimigoPadrao : MonoBehaviour
{
    public GameObject Player;
    public AIDestinationSetter AiPath;
    public Animator anim;
    public int Dano;

    void Start()
    {
        Player = GameObject.FindGameObjectsWithTag("Player")[0];
        AiPath = gameObject.GetComponent<AIDestinationSetter>();
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AiPath.target = Player.transform;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log(collision);
            collision.GetComponent<Player>().TakeDamage(Dano);
            anim.SetTrigger("Ataque");
        }
    }
}

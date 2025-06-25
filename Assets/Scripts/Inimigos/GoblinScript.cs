using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class GoblinScript : MonoBehaviour
{
    public GameObject Player;
    public AIDestinationSetter AiPath;
    public Animator anim;

    public GameObject AreaDano;
    public float range;
    public LayerMask PlayerLayer;

    public float TimerAtaque;
    public float TimerAtaqueC;
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
        TimerAtaqueC -= Time.deltaTime;

        if(TimerAtaqueC <= 0)
        {
            Collider2D[] Acertou = Physics2D.OverlapCircleAll(AreaDano.transform.position, range, PlayerLayer);
            foreach (Collider2D inimigo in Acertou)
            {
                Debug.Log("Acertou " + inimigo.name);
                anim.SetTrigger("Ataque");
                AreaDano.SetActive(true);
                TimerAtaqueC = TimerAtaque;
            }
        }        
    }
    
    void OnDrawGizmosSelected()
    {
        if (AreaDano == null)
            return;

        Gizmos.DrawWireSphere(AreaDano.transform.position, range);
    }
}

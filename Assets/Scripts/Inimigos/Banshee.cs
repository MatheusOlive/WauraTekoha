using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class Banshee : MonoBehaviour
{
    public GameObject Player;
    public AIDestinationSetter AiPath;
    public float TiroTimer;
    public float TiroTimerC;
    public GameObject Projetil;
    public GameObject Arma;
    public GameObject Arma2;
    public Animator anim;
    void Start()
    {
        Player = GameObject.FindGameObjectsWithTag("Player")[0];
        AiPath = gameObject.GetComponent<AIDestinationSetter>();
    }

    // Update is called once per frame
    void Update()
    {
        AiPath.target = Player.transform;
        TiroTimerC -= Time.deltaTime;

        if(TiroTimerC <= 0)
        {
            anim.SetTrigger("Ataque");
            Instantiate(Projetil, Arma.transform.position, Arma.transform.rotation).GetComponent<BansheeProjetil>().alvo = Player.transform;
            Instantiate(Projetil, Arma2.transform.position, Arma2.transform.rotation).GetComponent<BansheeProjetil>().alvo = Player.transform;
            
            TiroTimerC = TiroTimer;
        }
    }

}

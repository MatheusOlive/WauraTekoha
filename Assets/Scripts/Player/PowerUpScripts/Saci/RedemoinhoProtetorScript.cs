using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedemoinhoProtetorScript : MonoBehaviour
{
    public float Dano = 0.1f;
    public float AcrecimoDeDano;
    public float CurrentDano = 0.1f;

    public Transform Areadano;
    public float range;
    public LayerMask inimigoLayer;

    public float TimerInicial;    
    public float TimerDesabilitadoInicial;
    
    public float Timer;
    public float TimerDesabilitado;

    public int level = 1;

    public float Velocidade;
    void Start()
    {
        Areadano = gameObject.transform;
        Timer = TimerInicial;
        TimerDesabilitado = TimerDesabilitadoInicial;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Timer -= Time.deltaTime;

        if (Timer <= 0)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            CurrentDano = 0;
            TimerDesabilitado -= Time.deltaTime;
        }
        if (TimerDesabilitado <= 0)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            CurrentDano = Dano;
            Timer = TimerInicial;
            TimerDesabilitado = TimerDesabilitadoInicial;
        }

        transform.Rotate(0, 0, Velocidade);

        Collider2D[] Acertou = Physics2D.OverlapCircleAll(Areadano.position, range, inimigoLayer);
        foreach (Collider2D inimigo in Acertou)
        {
            Debug.Log("Acertou " + inimigo.name);
            inimigo.GetComponent<VidaInimigo>().TakeDamage(CurrentDano);
            Debug.Log(Dano);

        }
    }
    public void levelUp()
    {
        //aumenta o dano da habilidade em 10%
        Dano *= AcrecimoDeDano;
        level += 1;
    }
    void OnDrawGizmosSelected()
    {
        if (Areadano == null)
            return;
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(Areadano.position, range);
    }
}

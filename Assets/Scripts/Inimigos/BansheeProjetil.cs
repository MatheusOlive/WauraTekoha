using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BansheeProjetil : MonoBehaviour
{
    public int Dano;
    public float Velocidade;
    public Transform alvo; 
    public float suavidade; 
    public Vector3 novaPosicao;

    public float TimerFollow;
    public float TimerVida;
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        TimerFollow -= Time.deltaTime;
        TimerVida -= Time.deltaTime;

        if(TimerVida <= 0)
        {
            Destroy(gameObject);
        }
        
        if(TimerFollow >= 0)
        {
            if (alvo != null)
            {
                novaPosicao = Vector2.MoveTowards(gameObject.transform.position, alvo.position, suavidade * Time.deltaTime);

                transform.position = novaPosicao;

                // Calcula o vetor de direção
                Vector2 direcao = (alvo.position - transform.position).normalized;

                // Calcula o ângulo em radianos
                float angulo = Mathf.Atan2(direcao.y, direcao.x) * Mathf.Rad2Deg;

                // Rotaciona o objeto na direção do destino
                transform.rotation = Quaternion.AngleAxis(angulo, Vector3.forward);

            }
        }
        else
        {
            transform.Translate(Velocidade,0,0);
        }
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log(collision);
            collision.GetComponent<Player>().TakeDamage(Dano);
            Destroy(gameObject);
        }
    }
}

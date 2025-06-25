using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjetilSaci : MonoBehaviour
{
    public float Dano = 5;
    public float Velocidade;

    public float Vida = 5;

    void Start()
    {

    }

    private void FixedUpdate()
    {
        transform.parent = null;
        transform.Translate(Velocidade, 0,0);

        Vida -= Time.deltaTime;

        if(Vida < 0) Destroy(gameObject);

    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Inimigo"))
        {
            Destroy(gameObject);
            collision.GetComponent<VidaInimigo>().TakeDamage(Dano);
        }
    }
}

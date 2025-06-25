using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaInimigo : MonoBehaviour
{
    public GameObject XpPoint;
    
    public static GameObject Estatisticas;
    public float vida; 
    // Start is called before the first frame update
    void Start()
    {
        Estatisticas = GameObject.FindGameObjectsWithTag("Estatisticas")[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (vida <= 0)
        {
            Estatisticas.GetComponent<EstatiscaScript>().ContadorMonstrosMortos ++;
            Destroy(gameObject);
            Instantiate(XpPoint, gameObject.transform.position, gameObject.transform.rotation);
        }
    }

    public void TakeDamage(float Dano)
    {
        vida -= Dano;
        Debug.Log(Dano);
    }

}

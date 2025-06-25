using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regenerador : MonoBehaviour
{
    public int Valor;

    public float TempoDeVida;
    private void Update() 
    {
        TempoDeVida -= Time.deltaTime;

        if(TempoDeVida <= 0)
        {
            Destroy(gameObject);
        }
    }
}

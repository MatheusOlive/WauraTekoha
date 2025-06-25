using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistribuicaoDePowerUps : MonoBehaviour
{
    public GameObject[] PowerUpsDisponiveis;
    public int[] RandomPowerUp;
    public GameObject[] Pivot;
    public bool TESTE;


    void Update(){
        if(TESTE){
            Distribuidor();
        }
    }
    public void Distribuidor()
    {
        RandomPowerUp = GerarNumerosAleatorios(PowerUpsDisponiveis.Length -1, 0, 3);
        
        for (int i = 0; i < RandomPowerUp.Length; i++)
        {   
            
            if(i > 3)
            {
                PowerUpsDisponiveis[i].transform.position = Pivot[RandomPowerUp[3]].transform.position;
            }
            else
            {
                PowerUpsDisponiveis[i].transform.position = Pivot[RandomPowerUp[i]].transform.position;
            }
            PowerUpsDisponiveis[i].SetActive(true);
            print(PowerUpsDisponiveis[i].transform.position);
        }
    }


    int[] GerarNumerosAleatorios(int quantidade, int minimo, int maximo)
    {
        int[] numerosPossiveis = new int[maximo - minimo + 1];
        int[] numerosAleatorios = new int[quantidade];

        // Preencha o array de números possíveis
        for (int i = 0; i < numerosPossiveis.Length; i++)
        {
            numerosPossiveis[i] = minimo + i;
        }

        // Embaralhe o array de números possíveis
        for (int i = 0; i < numerosPossiveis.Length; i++)
        {
            int temp = numerosPossiveis[i];
            int randomIndex = Random.Range(i, numerosPossiveis.Length);
            numerosPossiveis[i] = numerosPossiveis[randomIndex];
            numerosPossiveis[randomIndex] = temp;
        }

        // Pegue os números solicitados do array embaralhado
        for (int i = 0; i < quantidade; i++)
        {
            numerosAleatorios[i] = numerosPossiveis[i];
        }
        Debug.Log(numerosAleatorios);
        return numerosAleatorios;
    }
}
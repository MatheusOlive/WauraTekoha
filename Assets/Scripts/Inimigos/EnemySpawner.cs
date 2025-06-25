using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Inimigos")]
    public GameObject[] Spawners;
    public GameObject[] Enemys;
    public int[] ProbabilidadeSpawnEnemy;
    public int RandomSpawnPosition;
    public int RandomEnemy;
    public int Spawnado;

    public float Timer;
    public float TimerCount;
    public bool comecou;

    public int ContadorMonstros;
    

    [Header("Regeneração de vida")]
    public GameObject[] RegeneradoresDeVida;
    public float TimerVida;
    public float TimerCountVida;
    public int ContadorVidas;

    public void Start()
    {
        
    }
    public void Update()
    {
        ContadorMonstros = GameObject.FindGameObjectsWithTag("Inimigo").Length;
        ContadorVidas = GameObject.FindGameObjectsWithTag("VidaRegen").Length;
        
        if (!comecou)
        {
            AstarPath.active.Scan();
            comecou = true;
        }
        Timer -= Time.deltaTime / 100;
        if(Timer <= 0.2)
        {
            Timer = 0.1f;
        }
        TimerCount += Time.deltaTime;
        RandomSpawnPosition = Random.Range(0, Spawners.Length);
        RandomEnemy = Random.Range(0, 100);

        if(RandomEnemy <= ProbabilidadeSpawnEnemy[2])
        {
            Spawnado = 2;
        }
        else if(RandomEnemy <= ProbabilidadeSpawnEnemy[1])
        {
            Spawnado = 1;
        }
        else if(RandomEnemy <= ProbabilidadeSpawnEnemy[0])
        {
            Spawnado = 0;
        }

        if (TimerCount >= Timer && ContadorMonstros < 20)
        {

            TimerCount = 0;
            Instantiate(Enemys[Spawnado], 
                Spawners[RandomSpawnPosition].transform.position, 
                Spawners[RandomSpawnPosition].transform.rotation);

        }


        TimerCountVida -= Time.deltaTime;

        if(TimerCountVida <= 0 && ContadorVidas < 10)
        {
            Instantiate(RegeneradoresDeVida[0], 
                Spawners[RandomSpawnPosition].transform.position, 
                Spawners[RandomSpawnPosition].transform.rotation);

            TimerCountVida = TimerVida;
        }
    }

}

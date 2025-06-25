using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSaciScript : MonoBehaviour
{
    //Ybytu Mbo'y == Vento Protetor
    //Redemoinho que segue o player dando dano em inimigos que entram nele 


    [Header("Ybytu Mbo'y")]
    public GameObject RedemoinhoProtetor;
    public GameObject PowerUpUi;
    public int LevelYbytuMboy = 0;

    [Header("Mbo'y")]
    public GameObject Player;
    public float PowerUpResistencia = 1.1f;

    [Header("Naur�")]
    public GameObject Mira;
        public float PowerUpDano = 1.1f;
    public void Update()
    {
        RedemoinhoProtetor = gameObject.transform.GetChild(0).gameObject;
    }
    public void YbytuMboy()
    {
        if(LevelYbytuMboy == 0)
        {
            Instantiate(RedemoinhoProtetor, gameObject.transform);
            LevelYbytuMboy += 1;
            PowerUpUi.SetActive(false);
            desPause();
        }
        else
        {
            RedemoinhoProtetor.GetComponent<RedemoinhoProtetorScript>().levelUp();
            PowerUpUi.SetActive(false);
            desPause();
        }
    }
    public void Nauru()
    {
        Mira.GetComponent<PlayerAim>().Dano *= PowerUpDano;
        PowerUpUi.SetActive(false);
        desPause();
    }
    public void Mboy()
    {
        Player.GetComponent<Player>().Resistencia *= PowerUpResistencia;
        PowerUpUi.SetActive(false);
        desPause();
    }

    public void Apuama()
    {
        Player.GetComponent<Player>().ApuamaMetodo();
        PowerUpUi.SetActive(false);
        desPause();
    }

    public void desPause(){
        Time.timeScale = 1;
    }
}

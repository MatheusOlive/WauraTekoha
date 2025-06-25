using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsScript : MonoBehaviour
{
    public GameObject Mira;

    // Update is called once per frame
    void Update()
    {
        if(Mira.GetComponent<PlayerAim>().Personagems == PlayerAim.Personagem.Saci)
        {
            UpgradesSaci();
        } 
        if(Mira.GetComponent<PlayerAim>().Personagems == PlayerAim.Personagem.Iara)
        {
            UpgradesIara();
        } 
        if(Mira.GetComponent<PlayerAim>().Personagems == PlayerAim.Personagem.Curupira)
        {
            UpgradesCurupira();
        }
    }

    public void UpgradesSaci()
    {
        
    }
    public void UpgradesIara()
    {

    }
    public void UpgradesCurupira()
    {

    }
}

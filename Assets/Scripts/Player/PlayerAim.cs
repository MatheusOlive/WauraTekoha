using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    public enum Personagem { Saci, Iara, Curupira }

    [Header("Personagem Jogavel Portador do Script")]

    [Space]
    public Personagem Personagems;
    [Space]

    public int Vida;
    private Camera mainCam;
    private Vector3 mousePos;

    private GameObject Player;

    [Header("Saci")]
    public GameObject TiroSaci;
    public float CountDownSaci;
    public float CountFixedSaci = 1;
    public float Dano;
    int VidaSaci = 10;
    public AudioSource audioAtack;

    private void Start()
    {
        mainCam = GameObject.FindGameObjectsWithTag("MainCamera")[0].GetComponent<Camera>();
        Player = GameObject.FindGameObjectsWithTag("Player")[0];

        CountDownSaci = CountFixedSaci;


        if (Personagems == Personagem.Saci)
        {
            Vida = VidaSaci;
            gameObject.GetComponentInParent<Player>().Vida = Vida;
        }
    }
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0,0, rotZ);
        //Debug.Log(rotZ);

        
        if(rotZ > 90f || rotZ < -90f)
        {
            Player.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            Player.GetComponent<SpriteRenderer>().flipX = false;
        }

        if (Personagems == Personagem.Saci)
        {
            Saci();
        }
    }


    public void Saci()
    {
        //Debug.Log(Personagems);
        
        CountDownSaci -= Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            if (CountDownSaci <= 0)
            {
                GameObject Projetio = Instantiate(TiroSaci, gameObject.transform.position, gameObject.transform.rotation);
                audioAtack.Play();
                Projetio.GetComponent<ProjetilSaci>().Dano = Dano;
                CountDownSaci = CountFixedSaci;
            }
        }
    }


}

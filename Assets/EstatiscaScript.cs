using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EstatiscaScript : MonoBehaviour
{
    public Text TxtNiveis;
    public Text TxtMonstrosMortos;

    public int ContadorMonstrosMortos;
    public GameObject Player;
    void Start()
    {
        Player = GameObject.FindGameObjectsWithTag("Player")[0];
    }

    // Update is called once per frame
    void Update()
    {
        TxtNiveis.text = Player.GetComponent<Player>().Nivel.ToString();
        TxtMonstrosMortos.text = ContadorMonstrosMortos.ToString();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuScript : MonoBehaviour
{
    public void Jogar()
    {
        SceneManager.LoadScene("Main");
    }

    public void Sair()
    {
        Application.Quit();
    }
}

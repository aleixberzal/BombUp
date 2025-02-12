using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public void Juego()
    {
        Debug.Log("Juego");
        SceneManager.LoadScene("Juego");
    }

    public void Salir()
    {
        Debug.Log("Salir");
        Application.Quit();
    }
}

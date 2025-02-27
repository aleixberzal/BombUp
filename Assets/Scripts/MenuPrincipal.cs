using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public GameObject menuConfiguracion;

    private void Start()
    {
        menuConfiguracion.SetActive(false);
    }
    public void Juego()
    {
        Debug.Log("Juego");
        SceneManager.LoadScene("Escena Principal");
    }

    public void Salir()
    {
        Debug.Log("Salir");
        Application.Quit();
    }

    public void Config()
    {
        menuConfiguracion.SetActive(true);
    }
    public void CerrarConfiguracion()
    {
        menuConfiguracion.SetActive(false);
    }
}

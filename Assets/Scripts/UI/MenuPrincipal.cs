using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class MenuPrincipal : MonoBehaviour
{
    public GameObject menuConfiguracion;
    public SaveLoadManager saveLoadManager;

    void Start()
    {
        menuConfiguracion.SetActive(false);
    }

    public void NuevaPartida()
    {
        SceneManager.LoadScene("Save UI");
    }

    public void Salir()
    {
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

    public void CargarPartida()
    {
        SceneManager.LoadScene("AlphaGreyMap");
    }

    public void Creditos()
    {
        SceneManager.LoadScene("Creditos");
    }
}

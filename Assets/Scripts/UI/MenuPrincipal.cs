using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;

public class MenuPrincipal : MonoBehaviour
{
    public GameObject menuConfiguracion;
    public GameObject menuAudio;
    public SaveLoadManager saveLoadManager;
    public Button miBoton1;
    public Button miBoton2;
    public Button miBoton3;
    public Button miBoton4;
    public Button miBoton5;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        menuConfiguracion.SetActive(false);
    }

    public void NuevaPartida()
    {
        SceneManager.LoadScene("Intro");
    }

    public void Challenge()
    {
        SceneManager.LoadScene("Challenge");
    }

    public void Salir()
    {
        Application.Quit();
    }

    public void Config()
    {
        menuConfiguracion.SetActive(true);
        miBoton1.interactable = false;
        miBoton2.interactable = false;
        miBoton3.interactable = false;
        miBoton4.interactable = false;
        miBoton5.interactable = false;
    }
    public void CerrarConfiguracion()
    {
        menuConfiguracion.SetActive(false);
        miBoton1.interactable = true;
        miBoton2.interactable = true;
        miBoton3.interactable = true;
        miBoton4.interactable = true;
        miBoton5.interactable = true;
    }

    public void CargarPartida()
    {
        SceneManager.LoadScene("AlphaGreyMap");
    }

    public void Creditos()
    {
        SceneManager.LoadScene("Creditos");
    }

    public void AbrirAudio()
    {
        menuAudio.SetActive(true);
    }

    public void AbrirRanking()
    {
        SceneManager.LoadScene("Ranking");
    }
}

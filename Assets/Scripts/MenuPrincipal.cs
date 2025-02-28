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
        string filePath = Application.persistentDataPath + "/playerData.json";
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }

        SceneManager.LoadScene("FerranScene");
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
        if (FindObjectOfType<SaveLoadManager>().ExistePartida())
        {
            SceneManager.LoadScene("FerranScene");
        }
        else
        {
            Debug.Log("No hay partida guardada.");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public GameObject menuConfiguracion;
    public SaveLoadManager saveLoadManager;

    private void Start()
    {
        menuConfiguracion.SetActive(false);
    }
    public void Juego()
    {
        Debug.Log("Juego");
        SceneManager.LoadScene("FerranScene");
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

    public void CargarPartida()
    {
        // Cargar los datos de la partida guardada
        PlayerData data = saveLoadManager.CargaPartida();
        if (data != null)
        {
            // Si la partida existe, cargamos la escena del juego
            SceneManager.LoadScene("FerranScene");  // Reemplaza "Juego" por el nombre de tu escena del juego

            // También puedes pasar los datos al objeto de jugador si es necesario
            // Ejemplo: GameObject.Find("Jugador").GetComponent<Player>().CargarPosicion(data);
        }
        else
        {
            Debug.LogWarning("No se encontró una partida guardada.");
        }
    }
}

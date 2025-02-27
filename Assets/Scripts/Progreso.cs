using UnityEngine;
using System.Collections;
using static SaveLoadManager;

public class Progreso : MonoBehaviour
{
    public SaveLoadManager saveLoadManager;

    void Start()
    {
        // Cargar los datos de la partida al iniciar la escena
        PlayerData data = saveLoadManager.CargaPartida();
        if (data != null)
        {
            // Mover al jugador a la posición guardada
            transform.position = new Vector3(data.playerPositionX, data.playerPositionY, transform.position.z);
            Debug.Log("Jugador cargado en la posición: " + transform.position);
        }
        else
        {
            Debug.LogWarning("No se encontró una partida guardada.");
        }
    }
}
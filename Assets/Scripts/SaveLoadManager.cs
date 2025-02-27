using UnityEngine;
using System.IO;

public class SaveLoadManager : MonoBehaviour
{
    private string filePath;

    void Start()
    {
        filePath = Application.persistentDataPath + "/playerData.json"; // Asegúrate de que esta ruta sea correcta
    }

    // Función para guardar los datos
    public void GuardaPartida(PlayerData data)
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(filePath, json);
        Debug.Log("Partida guardada.");
    }

    // Función para cargar los datos
    public PlayerData CargaPartida()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json); // Convertimos el JSON en un objeto
            Debug.Log("Partida cargada.");
            return data;
        }
        else
        {
            Debug.LogWarning("No se encontró una partida guardada.");
            return null; // Si no existe el archivo, devuelve null
        }
    }
}

[System.Serializable]
public class PlayerData
{
    public float playerPositionX;
    public float playerPositionY;
    public bool bomba1;
    public bool bomba2;  // Otros datos que quieras guardar
}


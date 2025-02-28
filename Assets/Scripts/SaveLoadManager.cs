using UnityEngine;
using System.IO;

public class SaveLoadManager : MonoBehaviour
{
    private string filePath;
    public static SaveLoadManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        filePath = Application.persistentDataPath + "/playerData.json";
    }

    public void GuardaPartida(PlayerData data)
    {
        string json = JsonUtility.ToJson(data);
        Debug.Log($"Escribiendo archivo: {json}");

        File.WriteAllText(filePath, json);
        Debug.Log($"Partida guardada en: {filePath}");
    }


    public PlayerData CargaPartida()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            Debug.Log("Contenido del archivo guardado: " + json); // Imprimir el contenido del archivo
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);
            Debug.Log($"Partida cargada: Posición X={data.playerPositionX}, Y={data.playerPositionY}");
            return data;
        }
        else
        {
            Debug.Log("No se encontró un archivo de guardado.");
            return null;
        }
    }


    public bool ExistePartida()
    {
        return File.Exists(filePath);
    }
}

[System.Serializable]
public class PlayerData
{
    public float playerPositionX;
    public float playerPositionY;
}

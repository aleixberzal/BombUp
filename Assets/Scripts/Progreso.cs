using UnityEngine;
using UnityEngine.SceneManagement;

public class Progreso : MonoBehaviour
{
    public SaveLoadManager saveLoadManager;
    private float saveInterval = 5f;
    private float saveTimer = 0f;

    void Start()
    {
        saveLoadManager = FindObjectOfType<SaveLoadManager>();

        if (saveLoadManager != null)
        {
            PlayerData data = saveLoadManager.CargaPartida();
            if (data != null)
            {
                transform.position = new Vector3(data.playerPositionX, data.playerPositionY, transform.position.z);
            }
        }
    }

    void Update()
    {
        saveTimer += Time.deltaTime;
        if (saveTimer >= saveInterval)
        {
            GuardarProgreso();
            saveTimer = 0f;
        }
    }

    public void GuardarProgreso()
    {
        if (saveLoadManager != null)
        {
            PlayerData data = new PlayerData
            {
                playerPositionX = transform.position.x,
                playerPositionY = transform.position.y
            };

            Debug.Log($"Guardando posición: X={data.playerPositionX}, Y={data.playerPositionY}");

            saveLoadManager.GuardaPartida(data);
        }
    }

}

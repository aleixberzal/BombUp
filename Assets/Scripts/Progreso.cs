using UnityEngine;
using UnityEngine.SceneManagement;

public class Progreso : MonoBehaviour
{
    public SaveLoadManager saveLoadManager;
    private float saveInterval = 5f;
    private float saveTimer = 0f;
    public bool bomba1desbloqueada = false;
    public bool bomba2desbloqueada = false;
    public bool bomba3desbloqueada = false;

    void Start()
    {
        saveLoadManager = FindObjectOfType<SaveLoadManager>();

        if (saveLoadManager != null)
        {
            PlayerData data = saveLoadManager.CargaPartida();
            if (data != null)
            {
                transform.position = new Vector3(data.playerPositionX, data.playerPositionY, transform.position.z);
                bomba1desbloqueada = data.bomba1desbloqueada;
                bomba2desbloqueada = data.bomba2desbloqueada;
                bomba3desbloqueada = data.bomba3desbloqueada;
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
                playerPositionY = transform.position.y,
                bomba1desbloqueada = bomba1desbloqueada,
                bomba2desbloqueada = bomba2desbloqueada,
                bomba3desbloqueada = bomba3desbloqueada
            };

            Debug.Log($"Guardando posición: X={data.playerPositionX}, Y={data.playerPositionY}");

            saveLoadManager.GuardaPartida(data);
        }
    }

}

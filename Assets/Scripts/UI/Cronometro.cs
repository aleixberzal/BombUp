using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Cronometro : MonoBehaviour
{
    public TMP_Text cronometroTexto;
    public TMP_InputField inputNombre;
    //public GameObject panelGuardarNombre;
    public Button botonGuardar;
    public float tiempoTranscurrido = 0f;
    private bool contando = true;

    void Start()
    {
        IniciarCronometro();
        //panelGuardarNombre.SetActive(false);
        botonGuardar.onClick.AddListener(GuardarTiempoConNombre);
    }

    void Update()
    {
        if (contando)
        {
            tiempoTranscurrido += Time.deltaTime;
            ActualizarTexto();
        }
    }

    void ActualizarTexto()
    {
        int minutos = Mathf.FloorToInt(tiempoTranscurrido / 60);
        int segundos = Mathf.FloorToInt(tiempoTranscurrido % 60);
        cronometroTexto.text = string.Format("{0:00}:{1:00}", minutos, segundos);
    }

    public void IniciarCronometro()
    {
        contando = true;
    }

    public void DetenerCronometro()
    {
        contando = false;
        //panelGuardarNombre.SetActive(true);
    }

    public void GuardarTiempoConNombre()
    {
        string nombre = inputNombre.text;
        if (string.IsNullOrEmpty(nombre)) nombre = "Jugador";

        Ranking ranking = Ranking.Cargar();
        ranking.AgregarTiempo(nombre, tiempoTranscurrido);
        ranking.Guardar();

        //panelGuardarNombre.SetActive(false);
    }

    public void ReiniciarCronometro()
    {
        tiempoTranscurrido = 0f;
        ActualizarTexto();
    }
}
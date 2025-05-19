using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Cronometro : MonoBehaviour
{
    public TMP_Text cronometroTexto;
    public TMP_InputField inputNombre;
    public float tiempoChallenge = 300f;
    //public GameObject panelGuardarNombre;
    public Button botonGuardar;
    public float tiempoTranscurrido = 0f;
    private bool contando = true;
    public string nombreEscena;
    public float tiempoRestante;

    void Start()
    {
        nombreEscena = SceneManager.GetActiveScene().name;
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
        if (nombreEscena == "Challenge")
        {
            tiempoRestante = tiempoChallenge;
            tiempoRestante -= tiempoTranscurrido;
            int minutos = Mathf.FloorToInt(tiempoRestante / 60);
            int segundos = Mathf.FloorToInt(tiempoRestante % 60);
            cronometroTexto.text = string.Format("{0:00}:{1:00}", minutos, segundos);
        }
        else
        {
            int minutos = Mathf.FloorToInt(tiempoTranscurrido / 60);
            int segundos = Mathf.FloorToInt(tiempoTranscurrido % 60);
            cronometroTexto.text = string.Format("{0:00}:{1:00}", minutos, segundos);
        }
        
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
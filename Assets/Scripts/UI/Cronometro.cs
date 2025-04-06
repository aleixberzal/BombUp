using UnityEngine;
using TMPro;

public class Cronometro : MonoBehaviour
{
    public TMP_Text cronometroTexto;
    public float tiempoTranscurrido = 0f;
    private bool contando = true;

    void Start()
    {
        IniciarCronometro();
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
    }

    public void ReiniciarCronometro()
    {
        tiempoTranscurrido = 0f;
        ActualizarTexto();
    }
}

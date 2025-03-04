using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBomba : MonoBehaviour
{
    public BoostIndicator BoostIndicator;

    [SerializeField] private Explosiones explosiones;
    [SerializeField] private Color targetColor = Color.red; // Color al que cambiará el objeto
    [SerializeField] private float changeDuration = 0.3f;    // Duración del cambio de color
    [SerializeField] private float tiempo = 3f;          // Intervalo entre cambios

    private Renderer objectRenderer;                       // Referencia al Renderer del objeto
    private Color originalColor;                           // Color original del objeto

    public float currentTime = 0;
    public bool hasExploded = false;

    void Start()
    {
        // Obtener el Renderer del objeto
        objectRenderer = GetComponent<Renderer>();

        if (objectRenderer != null)
        {
            // Guardar el color original del material
            originalColor = objectRenderer.material.color;
        }
        else
        {
            Debug.LogError("No se encontró un Renderer en el objeto.");
        }
    }

    private void Update()
    {
        if (!hasExploded)
        {
            currentTime += Time.deltaTime;
            if (currentTime >= tiempo){
                hasExploded = true;
                explosiones.Explode();
                BoostIndicator.bomb1Active = false;
            }
        }
        
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBomba : MonoBehaviour
{
<<<<<<< HEAD
    public BoostIndicator boostIndicator;
=======
>>>>>>> 24fbffde40fd07c421314f9d4a8c1aea6d445d1e

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
<<<<<<< HEAD
                boostIndicator.bomb1Active = false;
=======
>>>>>>> 24fbffde40fd07c421314f9d4a8c1aea6d445d1e
            }
        }
        
    }

}

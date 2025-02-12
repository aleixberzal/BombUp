using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBomba : MonoBehaviour
{
    [SerializeField] private Explosiones explosiones;
    [SerializeField] private Color targetColor = Color.red; // Color al que cambiará el objeto
    [SerializeField] private float changeDuration = 0.3f;    // Duración del cambio de color
    [SerializeField] private float interval = 3f;          // Intervalo entre cambios

    private Renderer objectRenderer;                       // Referencia al Renderer del objeto
    private Color originalColor;                           // Color original del objeto

    void Start()
    {
        // Obtener el Renderer del objeto
        objectRenderer = GetComponent<Renderer>();

        if (objectRenderer != null)
        {
            // Guardar el color original del material
            originalColor = objectRenderer.material.color;

            // Iniciar la corrutina para cambiar de color
            StartCoroutine(ChangeColorRoutine());
        }
        else
        {
            Debug.LogError("No se encontró un Renderer en el objeto.");
        }
    }

    private IEnumerator ChangeColorRoutine()
    {
        while (true)
        {
            // Esperar el intervalo inicial antes de cambiar de color
            yield return new WaitForSeconds(interval);

            explosiones.Explode();

            // Cambiar al color objetivo
            objectRenderer.material.color = targetColor;

            // Esperar durante el tiempo de duración
            yield return new WaitForSeconds(changeDuration);

            // Volver al color original
            objectRenderer.material.color = originalColor;
        }
    }
}

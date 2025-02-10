using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class bombaTiempo : MonoBehaviour
{
    public GameObject contadorPrefab; // Prefab del contador (Texto)
    public Canvas canvas; // Asigna el Canvas en el Inspector
    public float tiempoExplosion = 3f; // Tiempo antes de explotar

    private GameObject contadorInstanciado;
    private TextMeshProUGUI contadorTexto; // Usamos TextMeshProUGUI para UI

    void Start()
    {
        // Instanciar el texto del contador dentro del Canvas
        contadorInstanciado = Instantiate(contadorPrefab, canvas.transform);

        // Obtener el componente TextMeshProUGUI
        contadorTexto = contadorInstanciado.GetComponent<TextMeshProUGUI>();

        // Llamar a la cuenta regresiva
        StartCoroutine(ActualizarCuentaRegresiva());
    }

    IEnumerator ActualizarCuentaRegresiva()
    {
        float tiempoRestante = tiempoExplosion;

        while (tiempoRestante > 0)
        {
            // Actualizar el texto en cada ciclo de la cuenta regresiva
            if (contadorTexto != null)
            {
                contadorTexto.text = tiempoRestante.ToString("0"); // Mostrar número entero
            }

            yield return new WaitForSeconds(1f);
            tiempoRestante--;
        }

        Destroy(contadorInstanciado, 1f); // Destruir el texto después de 1 segundo
        Explota();
    }

    void Explota()
    {
        Destroy(gameObject); // Destruye la bomba
    }

    void Update()
    {
        if (contadorInstanciado != null)
        {
            // Depurar la posición del texto
            Debug.Log("Posición del contador: " + contadorInstanciado.transform.position);

            // Actualiza la posición del texto sobre la bomba
            contadorInstanciado.transform.position = transform.position + Vector3.up * 1f;
        }
    }
}

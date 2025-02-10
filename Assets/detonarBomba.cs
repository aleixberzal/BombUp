using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detonarBomba : MonoBehaviour
{
    public string tagBuscado = "Bomba3";

    void Update()
    {
        // Buscar un objeto con el tag "Bomba3"
        GameObject bomba = GameObject.FindGameObjectWithTag(tagBuscado);

        // Si existe una bomba y se presiona la tecla L
        if (bomba != null && (Input.GetKeyDown(KeyCode.L) || Input.GetKeyDown(KeyCode.C)))
        {
            // Obtener el componente Explosiones del GameObject
            Explosiones Explosiones = bomba.GetComponent<Explosiones>();

            // Si el componente existe, ejecutar la explosión
            if (Explosiones != null)
            {
                Explosiones.Explode();
            }
            else
            {
                Debug.Log("El script Explosiones no está asignado a la bomba.");
            }
        }
    }
}

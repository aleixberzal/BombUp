using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detonarBomba : MonoBehaviour
{
    public string tagBuscado = "Bomba2";

    void Update()
    {
        // Buscar un objeto con el tag "Bomba2"
        GameObject bomba = GameObject.FindGameObjectWithTag(tagBuscado);

        // Si existe una bomba y se presiona la tecla L
        if (bomba != null && (Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.X)))
        {
            // Obtener el componente Explosiones del GameObject
            Explosiones Explosiones = bomba.GetComponent<Explosiones>();

            // Si el componente existe, ejecutar la explosión
            if (Explosiones != null)
            {
                Explosiones.Explode();
                FindObjectOfType<ColocarBomba>().StartCooldownBomba2();
            }
            else
            {
                Debug.Log("El script Explosiones no está asignado a la bomba.");
            }
        }
    }
}

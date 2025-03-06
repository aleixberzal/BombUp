using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detonarBomba : MonoBehaviour
{
    public string tagBomb2 = "Bomba2";
    public string tagBomb3 = "Bomba3";


    void Update()
    {
        // Buscar un objeto con el tag "Bomba2"
        GameObject bomb2 = GameObject.FindGameObjectWithTag(tagBomb2);

        // Si existe una bomba y se presiona la tecla L
        if (bomb2 != null && (Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.X)))
        {
            // Obtener el componente Explosiones del GameObject
            Explosiones Explosiones = bomb2.GetComponent<Explosiones>();
            BombaPegajosa bombaPegajosa = bomb2.GetComponent<BombaPegajosa>();

            // Si el componente existe, ejecutar la explosión
            if (Explosiones != null && bombaPegajosa != null && bombaPegajosa.pegado)
            {
                Explosiones.Explode();
                FindObjectOfType<ColocarBomba>().StartCooldownBomba2();
            }
            else
            {
                Debug.Log("El script Explosiones no está asignado a la bomba.");
            }
        }

        GameObject bomb3 = GameObject.FindGameObjectWithTag(tagBomb3);
        if (bomb3 != null && (Input.GetKeyDown(KeyCode.L) || Input.GetKeyDown(KeyCode.C)))
        {
            Explosiones Explode3 = bomb3.GetComponent<Explosiones>();
            fireworkBomb fireworkBomb = bomb3.GetComponent<fireworkBomb>();

            if (Explode3 != null && fireworkBomb != null && fireworkBomb.ready)
            {
                fireworkBomb.SetReady(true);
                bomb3.GetComponent<Collider2D>().enabled = false;
            }
            else
            {
                Debug.Log("El script Explosiones no está asignado a la bomba.");
            }

        }
    }
}

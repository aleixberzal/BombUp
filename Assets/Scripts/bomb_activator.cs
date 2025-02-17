using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class bomb_activator : MonoBehaviour
{
    public Image boton2;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ColocarBomba bombaScript = collision.GetComponent<ColocarBomba>();

            if (bombaScript != null)
            {
                bombaScript.desbloquearSegundaBomba(); // Desbloquea la segunda bomba
                boton2.enabled = true;
            }

            Destroy(gameObject); // Elimina el objeto del escenario
        }
    }
}


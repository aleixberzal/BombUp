using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb_activator : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ColocarBomba bombaScript = collision.GetComponent<ColocarBomba>();

            if (bombaScript != null)
            {
                bombaScript.desbloquearSegundaBomba(); // Desbloquea la segunda bomba
            }

            Destroy(gameObject); // Elimina el objeto del escenario
        }
    }
}


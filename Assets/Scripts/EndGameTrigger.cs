using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Verifica si el jugador ha tocado la meta
        {
            Debug.Log("¡Has llegado a la meta!");
            EndGame();
        }
    }

    void EndGame()
    {
        Debug.Log("Fin del juego");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Detiene el juego en el editor
#else
    Application.Quit(); // Cierra la aplicación en una build
#endif
    }
}

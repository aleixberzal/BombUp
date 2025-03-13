using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        SceneManager.LoadScene("Creditos");
    }
}

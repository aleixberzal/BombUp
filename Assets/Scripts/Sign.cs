using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Sign : MonoBehaviour
{
    public GameObject mensajeUI; // cartel de "Presiona E"
    private bool jugadorCerca = false;  
    private bool signActivada = false;
    public GameObject turorial;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); 
    }

    // Update is called once per frame
    
    

    void Update()
    {
        if (jugadorCerca && Input.GetKeyDown(KeyCode.E))
        {
            signActivada = true;
            audioSource.Play();
            turorial.SetActive(true);
            mensajeUI.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = true;
            if (mensajeUI != null && signActivada == false) mensajeUI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = false;
            if (mensajeUI != null) mensajeUI.SetActive(false);
        }
    }
}

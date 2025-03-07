using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bomb_activator : MonoBehaviour
{
    public Image boton1; 
    public Image boton2; 
    public Image boton3;
    public GameObject tuto1;
    public GameObject tuto2;
    public GameObject tuto3;

    public enum BombaTipo { Primera, Segunda, Tercera }; // Enumeración para distinguir las bombas
    public BombaTipo tipoBomba; // Tipo de bomba que este objeto desbloquea
    public GameObject bomba1;
    public GameObject bomba2;
    public GameObject bomba3;

    void Start()
    {
        Progreso progreso = FindObjectOfType<Progreso>();
        ColocarBomba bombaScript = FindObjectOfType<ColocarBomba>();
        tuto1.SetActive(false);
        tuto2.SetActive(false);
        tuto3.SetActive(false);
        Debug.Log($"Bomba 1 desbloqueada: {progreso.bomba1desbloqueada}");
        Debug.Log($"Bomba 2 desbloqueada: {progreso.bomba2desbloqueada}");
        Debug.Log($"Bomba 3 desbloqueada: {progreso.bomba3desbloqueada}");
        //bomba1.SetActive(true);
        //bomba2.SetActive(true);
        //bomba3.SetActive(true);
        if (progreso.bomba1desbloqueada == true)
        {
            bombaScript.desbloquearPrimeraBomba();
            boton1.enabled = true;
            //bomba1.SetActive(false);
        }
        if (progreso.bomba2desbloqueada == true)
        {
            bombaScript.desbloquearSegundaBomba();
            boton2.enabled = true;
            bomba2.SetActive(false);
        }
        if (progreso.bomba3desbloqueada == true)
        {
            bombaScript.desbloquearTerceraBomba();
            boton3.enabled = true;
            bomba3.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ColocarBomba bombaScript = collision.GetComponent<ColocarBomba>();
            Progreso progreso = FindObjectOfType<Progreso>();

            if (bombaScript != null)
            {
                switch (tipoBomba)
                {
                    case BombaTipo.Primera:
                        bombaScript.desbloquearPrimeraBomba();
                        boton1.enabled = true;
                        progreso.bomba1desbloqueada = true;
                        mostrarTuto1();
                        break;
                    case BombaTipo.Segunda:
                        bombaScript.desbloquearSegundaBomba();
                        boton2.enabled = true;
                        progreso.bomba2desbloqueada = true;
                        mostrarTuto2();
                        break;
                    case BombaTipo.Tercera:
                        bombaScript.desbloquearTerceraBomba();
                        boton3.enabled = true;
                        progreso.bomba3desbloqueada = true;
                        mostrarTuto3();
                        break;
                }
            }

            Destroy(gameObject); // Elimina el objeto de la escena
        }
    }

    void mostrarTuto1()
    {
        tuto1.SetActive(true);
    }

    public void quitarTuto1()
    {
        tuto1.SetActive(false);
    }
    void mostrarTuto2()
    {
        tuto2.SetActive(true);
    }

    public void quitarTuto2()
    {
        tuto2.SetActive(false);
    }
    void mostrarTuto3()
    {
        tuto3.SetActive(true);
    }

    public void quitarTuto3()
    {
        tuto3.SetActive(false);
    }
}



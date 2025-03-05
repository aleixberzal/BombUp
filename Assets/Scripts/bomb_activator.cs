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

    void Start()
    {
        tuto1.SetActive(false);
        tuto2.SetActive(false);
        tuto3.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ColocarBomba bombaScript = collision.GetComponent<ColocarBomba>();

            if (bombaScript != null)
            {
                switch (tipoBomba)
                {
                    case BombaTipo.Primera:
                        bombaScript.desbloquearPrimeraBomba();
                        boton1.enabled = true;
                        mostrarTuto1();
                        break;
                    case BombaTipo.Segunda:
                        bombaScript.desbloquearSegundaBomba();
                        boton2.enabled = true;
                        mostrarTuto2();
                        break;
                    case BombaTipo.Tercera:
                        bombaScript.desbloquearTerceraBomba();
                        boton3.enabled = true;
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



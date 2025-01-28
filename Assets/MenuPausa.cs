using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{

    public GameObject PausaMenu;
    private bool isPaused = false;


    void Start()
    {
        PausaMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resumen();
            }
            else
            {
                Pausa();
            }
        }
    }
    void Pausa()
    {
        PausaMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Resumen()
    {
        PausaMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Salir()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuPrincipal");
    }

}

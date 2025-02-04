using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{

    public GameObject PausaMenu;
    public GameObject ConfiguracionMenu;
    private bool isPaused = false;


    void Start()
    {
        PausaMenu.SetActive(true);
        ConfiguracionMenu.SetActive(false);
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
    public void Pausa()
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

    public void Configuracion()
    {
        PausaMenu.SetActive(false);
        ConfiguracionMenu.SetActive(true);
    }

    public void OcultarOtroMenu()
    {
        ConfiguracionMenu.SetActive(false);
        PausaMenu.SetActive(true);
    }
    public void Salir()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuPrincipal");
    }

}

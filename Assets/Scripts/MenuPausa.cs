using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public GameObject PausaMenu;
    public GameObject ConfiguracionMenu;
    private bool isPaused = false;
    private bool configuracion = false;

    void Start()
    {
        Time.timeScale = 1f;
        Input.ResetInputAxes();
        PausaMenu.SetActive(false);
        ConfiguracionMenu.SetActive(false);
        isPaused = false;
        configuracion = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape presionado - isPaused: " + isPaused + ", configuracion: " + configuracion + ", Time.timeScale: " + Time.timeScale);

            if (configuracion)
            {
                OcultarOtroMenu();
            }
            else
            {
                if (!isPaused)
                    Pausa();
                else
                    Resumen();
            }
        }
    }


    public void Pausa()
    {
        PausaMenu.SetActive(true);
        ConfiguracionMenu.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;
        configuracion = false;
    }

    public void Resumen()
    {
        PausaMenu.SetActive(false);
        ConfiguracionMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        configuracion = false;
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
        configuracion = true;

    }

    public void OcultarOtroMenu()
    {
        ConfiguracionMenu.SetActive(false);
        PausaMenu.SetActive(true);
        configuracion = false;
    }

    public void Salir()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuPrincipal");
    }
}

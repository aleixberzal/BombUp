using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;

public class MenuPausa : MonoBehaviour
{
    public GameObject menuPausa;
    public GameObject menuConfiguracion;
    private bool estaPausado = false;
    private bool enConfiguracion = false;
    public Cronometro cronometro;

    void Start()
    {
        menuPausa.SetActive(false);
        menuConfiguracion.SetActive(false);
               
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (enConfiguracion)
            {
                MostrarMenuPausa();
            }
            else
            {
                AlternarPausa();
            }
        }
    }

    private void AlternarPausa()
    {
        if (estaPausado)
            Reanudar();
        else
            Pausar();
    }

    public void Pausar()
    {
        CambiarEstadoMenus(true, false);
        cronometro.DetenerCronometro();
        Time.timeScale = 0f;
        estaPausado = true;
    }

    public void Reanudar()
    {
        CambiarEstadoMenus(false, false);
        cronometro.IniciarCronometro();
        Time.timeScale = 1f;
        estaPausado = false;
    }

    public void Reiniciar()
    {
        Progreso progreso = FindObjectOfType<Progreso>();
        Time.timeScale = 1f;
        progreso.bomba1desbloqueada = false;
        progreso.bomba2desbloqueada = false;
        progreso.bomba3desbloqueada = false;
        string filePath = Application.persistentDataPath + "/playerData.json";
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }

        cronometro.ReiniciarCronometro();
        SceneManager.LoadScene("EscenaPrincipal");
    }

    public void AbrirConfiguracion()
    {
        CambiarEstadoMenus(false, true);
    }

    public void MostrarMenuPausa()
    {
        CambiarEstadoMenus(true, false);
    }

    public void Salir()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuPrincipal");
    }

    private void CambiarEstadoMenus(bool mostrarPausa, bool mostrarConfiguracion)
    {
        menuPausa.SetActive(mostrarPausa);
        menuConfiguracion.SetActive(mostrarConfiguracion);
        enConfiguracion = mostrarConfiguracion;
    }

    
}
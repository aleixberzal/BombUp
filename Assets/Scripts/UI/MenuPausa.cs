using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;

public class MenuPausa : MonoBehaviour
{
    public GameObject menuPausa;
    public GameObject menuConfiguracion;
    public GameObject menuReset;
    private bool estaPausado = false;
    private bool enConfiguracion = false;
    public Cronometro cronometro;
    public GameObject tuto1;
    public GameObject tuto2;
    public GameObject tuto3;
    public GameObject sign1;
    public GameObject sign2;
    public GameObject sign3;

    void Start()
    {
        menuPausa.SetActive(false);
        menuConfiguracion.SetActive(false);
        menuReset.SetActive(false);
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
        if (!tuto1.activeInHierarchy && !tuto2.activeInHierarchy && !tuto3.activeInHierarchy && !sign1.activeInHierarchy && !sign2.activeInHierarchy && !sign3.activeInHierarchy)
        {
            CambiarEstadoMenus(true, false);
            cronometro.DetenerCronometro();
            Time.timeScale = 0f;
            estaPausado = true;
        }
        else
        {
            tuto1.SetActive(false);
            tuto2.SetActive(false);
            tuto3.SetActive(false);
            sign1.SetActive(false);
            sign2.SetActive(false);
            sign3.SetActive(false);
        }
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
        SceneManager.LoadScene("Save UI");
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

    public void ResetSeguro()
    {
        menuPausa.SetActive(false);
        menuReset.SetActive(true);
    }

    public void ResetNo()
    {
        menuPausa.SetActive(true);
        menuReset.SetActive(false);
    }
}
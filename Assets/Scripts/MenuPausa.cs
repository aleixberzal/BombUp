using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Collections.Generic;

public class MenuPausa : MonoBehaviour
{
    public GameObject menuPausa;
    public GameObject menuConfiguracion;
    private bool estaPausado = false;
    private bool enConfiguracion = false;
    public AudioMixer audioMixer; 
    public Dropdown resolutionDropdown;
    public Dropdown fullscreenDropdown;
    public Slider volumeSlider;

    private List<Resolution> resolutions;
    private readonly List<string> resolutionOptions = new List<string>()
    {
        "1920 x 1080",
        "1280 x 720",
        "1600 x 900"
    };

    private readonly List<string> screenModeOptions = new List<string>()
    {
        "Pantalla Completa",
        "Ventana",
        "Ventana Sin Bordes"
    };

    void Start()
    {
        menuPausa.SetActive(false);
        menuConfiguracion.SetActive(false);

        resolutions = new List<Resolution>();

        // Agregar resoluciones predefinidas a la lista
        resolutions.Add(new Resolution { width = 1920, height = 1080 });
        resolutions.Add(new Resolution { width = 1280, height = 720 });
        resolutions.Add(new Resolution { width = 1600, height = 900 });

        resolutionDropdown.ClearOptions();

        int currentResolutionIndex = 0;
        List<string> options = new List<string>();

        // Llenar el dropdown con las resoluciones predefinidas
        for (int i = 0; i < resolutionOptions.Count; i++)
        {
            options.Add(resolutionOptions[i]);
            if (Screen.width == resolutions[i].width && Screen.height == resolutions[i].height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = PlayerPrefs.GetInt("resolution", currentResolutionIndex);
        resolutionDropdown.RefreshShownValue();

        fullscreenDropdown.AddOptions(screenModeOptions);
        fullscreenDropdown.value = PlayerPrefs.GetInt("screenMode", 0);  // 0: Pantalla Completa, 1: Ventana, 2: Ventana Sin Bordes
        fullscreenDropdown.RefreshShownValue();

        volumeSlider.value = PlayerPrefs.GetFloat("volume", 0.5f);

        ApplySettings();
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
        Time.timeScale = 0f;
        estaPausado = true;
    }

    public void Reanudar()
    {
        CambiarEstadoMenus(false, false);
        Time.timeScale = 1f;
        estaPausado = false;
    }

    public void Reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("volume", volume); 
    }

    public void SetScreenMode(int index)
    {
        PlayerPrefs.SetInt("screenMode", index);
        ApplySettings();
    }

    public void SetResolution(int index)
    {
        PlayerPrefs.SetInt("resolution", index);
        ApplySettings();
    }

    private void ApplySettings()
    {
        int resolutionIndex = PlayerPrefs.GetInt("resolution", 0);
        int screenModeIndex = PlayerPrefs.GetInt("screenMode", 0);

        bool isFullscreen = false;

        Resolution resolution = resolutions[resolutionIndex];

        Screen.SetResolution(resolution.width, resolution.height, isFullscreen ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed, resolution.refreshRateRatio);

        switch (screenModeIndex)
        {
            case 0: // Pantalla Completa
                isFullscreen = true;
                Screen.SetResolution(resolution.width, resolution.height, FullScreenMode.FullScreenWindow);
                break;
            case 1: // Ventana
                Screen.SetResolution(resolution.width, resolution.height, FullScreenMode.Windowed);
                break;
            case 2: // Ventana Sin Bordes
                Screen.SetResolution(resolution.width, resolution.height, FullScreenMode.MaximizedWindow);
                break;
        }
    }
}
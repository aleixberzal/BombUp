using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;

public class menuAudio : MonoBehaviour
{
    public GameObject MenuAudio;
    public GameObject menuConfiguracion;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Escape))
        {
            MenuAudio.SetActive(false);
            menuConfiguracion.SetActive(true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;

public class menuAudio : MonoBehaviour
{
    public GameObject MenuAudio;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            MenuAudio.SetActive(false);
        }
    }
}

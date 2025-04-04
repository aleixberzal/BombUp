using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutoScript : MonoBehaviour
{
    public GameObject tuto1;

    // Start is called before the first frame update
    void Start()
    {
        tuto1.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            mostrarTuto1();
        }
    }

    void mostrarTuto1()
    {
        tuto1.SetActive(true);
    }

    void quitarTuto()
    {
        tuto1.SetActive(false);
    }
}

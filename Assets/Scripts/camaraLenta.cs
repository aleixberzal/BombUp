using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camaraLenta : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float tiempoLento = 0.5f;
    public float tiempoNormal = 1.0f;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            camaraLenta1();
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            camaraNormal();
        }
    }
    public void camaraLenta1()
    {
        Time.timeScale = tiempoLento;
        Time.fixedDeltaTime = tiempoLento * 0.02f;
        Debug.Log("camara lenta");
    }

    public void camaraNormal()
    {
        Time.timeScale = tiempoNormal;
        Time.fixedDeltaTime = tiempoNormal * 0.02f;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheats : MonoBehaviour
{
    public GameObject tp1;
    public GameObject tp2;
    public GameObject tp3;
    public GameObject tp4;
    public ColocarBomba unblock;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1)) {
            transform.position = tp1.transform.position;
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            transform.position = tp2.transform.position;
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            transform.position = tp3.transform.position;
        }
        if (Input.GetKeyDown(KeyCode.F4))
        {
            transform.position = tp4.transform.position;
        }

        if (Input.GetKeyDown(KeyCode.F5))
        {
            unblock.desbloquearPrimeraBomba();
            unblock.desbloquearSegundaBomba();
            unblock.desbloquearTerceraBomba();
        }
    }
}

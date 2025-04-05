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

    public GameObject tpPrefab;
    private GameObject currentTp;
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
            if (currentTp != null)
            {
                Destroy(currentTp);
            }
            currentTp = Instantiate(tpPrefab, transform.position, Quaternion.identity);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            if (currentTp != null)
            {
                transform.position = currentTp.transform.position;
            }
        }

        if (Input.GetKeyDown(KeyCode.F7))
        {
            unblock.desbloquearPrimeraBomba();
            unblock.desbloquearSegundaBomba();
            unblock.desbloquearTerceraBomba();
        }
    }
}

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
        if (Input.GetKeyDown(KeyCode.F1))
        {
            // Mantén la posición actual en Z y actualiza X, Y
            transform.position = new Vector3(tp1.transform.position.x, tp1.transform.position.y, transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            transform.position = new Vector3(tp2.transform.position.x, tp2.transform.position.y, transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            transform.position = new Vector3(tp3.transform.position.x, tp3.transform.position.y, transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.F4))
        {
            transform.position = new Vector3(tp4.transform.position.x, tp4.transform.position.y, transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.F5))
        {
            if (currentTp != null)
            {
                Destroy(currentTp);
            }
            currentTp = Instantiate(tpPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            if (currentTp != null)
            {
                transform.position = new Vector3(currentTp.transform.position.x, currentTp.transform.position.y, transform.position.z);
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

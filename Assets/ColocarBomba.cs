using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColocarBomba : MonoBehaviour
{
    public GameObject bombaPrefab;  // Arrastra aquí el Prefab "Bomba basica"
    public Transform posicionBomba; // Posición donde se colocará la bomba
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))  // Cuando se presiona Espacio
        {

            if (GameObject.FindGameObjectWithTag("Bomba") == null)
            {
                ColocarBombaEnPosicion();  // Coloca la bomba
            }

            ColocarBombaEnPosicion();  // Coloca la bomba

        }
    }

    void ColocarBombaEnPosicion()
    {
        Instantiate(bombaPrefab, posicionBomba.position, Quaternion.identity);  // Instancia la bomba
    }
}

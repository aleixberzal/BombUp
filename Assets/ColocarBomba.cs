using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColocarBomba : MonoBehaviour
{
    public GameObject bombaPrefab1;  // Arrastra aquí el Prefab "Bomba basica"
    public GameObject bombaPrefab2;
    public Transform firePoint; // direccion donde dispara
    public float velocidadBomba = 10f;

    private Vector2 direccionBomba = Vector2.right;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if (moveX != 0 || moveY != 0)
        {
            direccionBomba = new Vector2(moveX, moveY).normalized;
        }
        if (Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.Z))  // Cuando se presiona la j o la z para controles alternativos
        {

            if (GameObject.FindGameObjectWithTag("Bomba1") == null)
            {
                LanzarBomba1();  // Coloca la bomba
            }
        }
        if (Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.X))  // Cuando se presiona la k o la x para controles alternativos
        {

            if (GameObject.FindGameObjectWithTag("Bomba2") == null)
            {
                LanzarBomba2();  // Coloca la bomba pegajosa
            }
        }
    }

    void LanzarBomba1()
    {
        GameObject bomba1 = Instantiate(bombaPrefab1, firePoint.position, Quaternion.identity);  // Instancia la bomba

        // Aplicar velocidad al proyectil
        Rigidbody2D rb = bomba1.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = direccionBomba * velocidadBomba;
        }
        bomba1.transform.right = direccionBomba;

    }

    void LanzarBomba2()
    {
        GameObject bomba2 = Instantiate(bombaPrefab2, firePoint.position, Quaternion.identity);  // Instancia la bomba

        // Aplicar velocidad al proyectil
        Rigidbody2D rb = bomba2.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = direccionBomba * velocidadBomba;
        }
        bomba2.transform.right = direccionBomba;
    }
}

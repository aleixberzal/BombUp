using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColocarBomba : MonoBehaviour
{
    public GameObject bombaPrefab;  // Arrastra aquí el Prefab "Bomba basica"
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

            if (GameObject.FindGameObjectWithTag("Bomba") == null)
            {
                LanzarBomba();  // Coloca la bomba
            }
        }
    }

    void LanzarBomba()
    {
        GameObject bomba1 = Instantiate(bombaPrefab, firePoint.position, Quaternion.identity);  // Instancia la bomba

        // Aplicar velocidad al proyectil
        Rigidbody2D rb = bomba1.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = direccionBomba * velocidadBomba;
        }
        bomba1.transform.right = direccionBomba;

    }
}

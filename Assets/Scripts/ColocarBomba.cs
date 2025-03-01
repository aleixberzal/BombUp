using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColocarBomba : MonoBehaviour
{
    public BoostIndicator boostIndicator; 


    public GameObject bombaPrefab1;  
    public GameObject bombaPrefab2;
    public GameObject bombaPrefab3;
    public Transform firePoint; // direccion donde dispara
    public float velocidadBomba = 10f;
    public float velocidadBomba3 = 20f;
    public bool primera_bomba = false;
    public bool segunda_bomba = false;
    public bool tercera_bomba = false;

    private Vector2 direccionBomba = Vector2.right;

    private float tiempoUltimaBomba2 = 0f;
    private float tiempoUltimaBomba3 = 0f;
    public float cooldownBomba2 = 0.2f;
    public float cooldownBomba3 = 0.2f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        direccionBomba = new Vector2(moveX, moveY).normalized;

        if (primera_bomba)
        {
            if (Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.Z))
            {

                if (GameObject.FindGameObjectWithTag("Bomba1") == null)
                {
                    LanzarBomba1();
                }
            }
        }

        if (segunda_bomba)
        {
            if ((Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.X)) && Time.time >= tiempoUltimaBomba2)
            {

                if (GameObject.FindGameObjectWithTag("Bomba2") == null)
                {
                    LanzarBomba2();  
                }
            }
        }

        if (tercera_bomba)
        {
            if ((Input.GetKeyDown(KeyCode.L) || Input.GetKeyDown(KeyCode.C)) && Time.time >= tiempoUltimaBomba3)
            {

                if (GameObject.FindGameObjectWithTag("Bomba3") == null)
                {
                    LanzarBomba3();
                }
            }
        }
    }
    public void StartCooldownBomba2()
    {
        tiempoUltimaBomba2 = Time.time + cooldownBomba2;
    }

    void LanzarBomba1()
    {
        GameObject bomba1 = Instantiate(bombaPrefab1, firePoint.position, Quaternion.identity);

        //Pass object position to indicator
        boostIndicator.bomb = bomba1.transform;

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


    void LanzarBomba3()
    {
        Vector2 direccionBomba;

        if (transform.localScale.x > 0) 
        {
            direccionBomba = Vector2.left; 
        }
        else 
        {
            direccionBomba = Vector2.right; 
        }

        
        GameObject bomba3 = Instantiate(bombaPrefab3, firePoint.position, Quaternion.identity);


        Rigidbody2D rb = bomba3.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = direccionBomba * velocidadBomba3;
        }

        bomba3.transform.right = direccionBomba;
        tiempoUltimaBomba3 = Time.time + cooldownBomba3;
    }


    public void desbloquearPrimeraBomba()
    {
        primera_bomba = true;
    }

    public void desbloquearSegundaBomba()
    {
        segunda_bomba = true;
    }

    public void desbloquearTerceraBomba()
    {
        tercera_bomba = true;
    }



}


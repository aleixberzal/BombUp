using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class primera_anim : MonoBehaviour
{
    public GameObject bombaPrefab1;  // Arrastra aquí el Prefab "Bomba basica" que tiene el Animator
    public GameObject bombaPrefab2;
    public GameObject bombaPrefab3;
    public Transform firePoint; // dirección donde dispara
    public float velocidadBomba = 10f;

    private Vector2 direccionBomba = Vector2.right;

    private float tiempoUltimaBomba3 = 0f;
    public float cooldownBomba3 = 3f;
    public bool segundaBomba = false;

    void Start()
    {

    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if (moveX != 0 || moveY != 0)
        {
            direccionBomba = new Vector2(moveX, moveY).normalized;
        }

        if (Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.Z)) // Cuando se presiona la j o la z para controles alternativos
        {
            if (GameObject.FindGameObjectWithTag("Bomba1") == null)
            {
                LanzarBomba1();  // Lanza la bomba con animación
            }
        }
        if (segundaBomba == true)
        {
            if (Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.X)) // Cuando se presiona la k o la x para controles alternativos
            {

                if (GameObject.FindGameObjectWithTag("Bomba2") == null)
                {
                    LanzarBomba2();  // Coloca la bomba pegajosa
                }
            }
        }
        if ((Input.GetKeyDown(KeyCode.L) || Input.GetKeyDown(KeyCode.C)) && Time.time >= tiempoUltimaBomba3 + cooldownBomba3) // Cuando se presiona la k o la x para controles alternativos
        {
            if (GameObject.FindGameObjectWithTag("Bomba3") == null)
            {
                LanzarBomba3();  // Coloca la bomba pegajosa
                tiempoUltimaBomba3 = Time.time;
            }
        }
    }

    void LanzarBomba1()
    {
        GameObject bomba1 = Instantiate(bombaPrefab1, firePoint.position, Quaternion.identity);  // Instancia la bomba

        // Aplicar velocidad al proyectil (si tu animación es en movimiento, no es necesario)
        Rigidbody2D rb = bomba1.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = direccionBomba * velocidadBomba;
        }

        bomba1.transform.right = direccionBomba;

        // Si quieres activar una animación al lanzar la bomba:
        Animator animator = bomba1.GetComponent<Animator>();
        if (animator != null)
        {
            animator.SetTrigger("Lanzar");  // Asegúrate de que tienes un trigger llamado "Lanzar" en tu Animator
        }
    }

    void LanzarBomba2()
    {
        GameObject bomba2 = Instantiate(bombaPrefab2, firePoint.position, Quaternion.identity);  // Instancia la bomba
        Rigidbody2D rb = bomba2.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = direccionBomba * velocidadBomba;
        }
        bomba2.transform.right = direccionBomba;
    }

    void LanzarBomba3()
    {
        GameObject bomba3 = Instantiate(bombaPrefab3, firePoint.position, Quaternion.identity);  // Instancia la bomba
        Rigidbody2D rb = bomba3.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = direccionBomba * velocidadBomba;
        }
        bomba3.transform.right = direccionBomba;
    }
    public void desbloquearSegundaBomba()
    {
        segundaBomba = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class FireworkBomb : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 5f;
    public bool startFlying = false;
    public bool isFlying = false;
    public bool Ontrigger = false;
    public bool pegado = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        

        if ((Input.GetKeyDown(KeyCode.L) || Input.GetKeyDown(KeyCode.C)))
        {
            if (pegado)
            {
                startFlying = true;
                rb.isKinematic = false;
                GetComponent<Collider2D>().enabled = true;
            }    
        }

        if (startFlying)
        {   
            if (Ontrigger)
            {
                GameObject bomb3 = GameObject.FindGameObjectWithTag("Bomba3");
                Explosiones explosiones = bomb3.GetComponent<Explosiones>();

                explosiones.Explode();
            }
            Vector2 direction = transform.up;
            rb.velocity = direction * speed;
            rb.gravityScale = 0f;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!pegado && collision.gameObject.CompareTag("Suelo"))
        {
            pegado = true;
            rb.velocity = Vector2.zero; // Detiene el movimiento
            rb.isKinematic = true; // Desactiva la física para que no caiga
            rb.angularVelocity = 0f;

            // Ajustar la rotación según la normal de la superficie
            Vector2 normal = collision.contacts[0].normal;
            float angle = Mathf.Atan2(normal.y, normal.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle - 90);
        }
    }

}

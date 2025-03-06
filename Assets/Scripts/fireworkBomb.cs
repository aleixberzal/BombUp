using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class fireworkBomb : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool ready = false;
    public float speed = 5f;
    public bool startFlying = false;
    public bool isFlying = false;
    int jugadorLayer =3;  // Capa de Jugador
    int bombaLayer =6;      // Capa de Bomba

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (startFlying)
        {
            isFlying = true;

            // Desactivar la ignorancia de colisiones entre las capas de Jugador y Bomba
            Physics2D.IgnoreLayerCollision(jugadorLayer, bombaLayer, false);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isFlying)
        {
            if (!ready && collision.gameObject.CompareTag("Suelo"))
            {
                ready = true;
                rb.velocity = Vector2.zero;
                rb.isKinematic = true;
                rb.angularVelocity = 0f;

            }
        } else
        {
            if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Suelo"))
            {
                // La bomba explota al tocar al jugador
                GameObject bomb3 = GameObject.FindGameObjectWithTag("Bomba3");
                Explosiones explosiones = bomb3.GetComponent<Explosiones>();

                explosiones.Explode();
                Physics2D.IgnoreLayerCollision(jugadorLayer, bombaLayer, true);
            }
        }

    }
    void Update()
    {

        if (startFlying)
        {
            rb.isKinematic = false;
            rb.velocity = new Vector2(0, speed);
            GetComponent<Collider2D>().enabled = true;
            
        }
    }

    public void SetReady(bool estado)
    {
        ready = estado;
        startFlying = true;
        if (!estado)
        {
            rb.isKinematic = true;
        }
    }
}

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

    private float standByTime = 0.1f;  // Tiempo en segundos
    private float passedTime = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        

        if ((Input.GetKeyDown(KeyCode.L) || Input.GetKeyDown(KeyCode.C)))
        {
            startFlying = true;
            rb.isKinematic = false;
            GetComponent<Collider2D>().enabled = true;
        }

        if (startFlying)
        {
            if (Ontrigger)
            {
                GameObject bomb3 = GameObject.FindGameObjectWithTag("Bomba3");
                Explosiones explosiones = bomb3.GetComponent<Explosiones>();

                explosiones.Explode();
            }
            rb.velocity = new Vector2(0, speed);
        }
    }
    
}

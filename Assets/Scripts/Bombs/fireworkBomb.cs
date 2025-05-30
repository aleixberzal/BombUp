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
    private float timeLeft = 0f;
    private bool timeOff = false;
    private AudioSource fireworkSound;
    [SerializeField] public ParticleSystem fuego;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        fireworkSound = GetComponent<AudioSource>();

    }

    void Update()
    {
        

        if ((Input.GetKeyDown(KeyCode.L) || Input.GetKeyDown(KeyCode.C)))
        {
            if (pegado)
            {
                startFlying = true;
                rb.isKinematic = false;
                fuego.Play();
                GetComponent<Collider2D>().enabled = true;

                if (!fireworkSound.isPlaying)
                    fireworkSound.Play();
            }    
        }

        if (startFlying)
        {

            timeLeft += Time.deltaTime;

            // Si la bomba no explota en 5 segundos explota sola y se destruye
            if (timeLeft >= 3f)
            {
                GameObject bomb3 = GameObject.FindGameObjectWithTag("Bomba3");
                if (bomb3 != null)
                {
                    Explosiones explosiones = bomb3.GetComponent<Explosiones>();
                    if (explosiones != null)
                    {
                        explosiones.Explode();
                    }
                }

                timeOff = true;
                Destroy(gameObject);
            }

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
        if ((!pegado && collision.gameObject.CompareTag("Suelo")) || (!pegado && collision.gameObject.CompareTag("Techo")))
        {
            pegado = true;
            rb.velocity = Vector2.zero;
            rb.isKinematic = true;
            rb.angularVelocity = 0f;

            Vector2 normal = collision.contacts[0].normal;
            float angle = Mathf.Atan2(normal.y, normal.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle - 90);
        }
    }
}

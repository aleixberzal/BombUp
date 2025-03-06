using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombaPegajosa : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool pegado = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void OnCollisionEnter2D(Collision2D collision)
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
    // Update is called once per frame
    void Update()
    {
        
    }
}

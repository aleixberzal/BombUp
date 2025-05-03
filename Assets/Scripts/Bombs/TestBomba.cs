using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBomba : MonoBehaviour
{

    //private Rigidbody2D rb;
    //public bool pegado = false;
    [SerializeField] private Explosiones explosiones;  
    [SerializeField] private float tiempo = 3f;     

    public float currentTime = 0;
    public bool hasExploded = false;

    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!hasExploded)
        {
            currentTime += Time.deltaTime;
            if (currentTime >= tiempo){
                hasExploded = true;
                explosiones.Explode();
            }
        }
        
    }

    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (!pegado && collision.gameObject.CompareTag("Suelo"))
    //    {
    //        pegado = true;
    //        rb.velocity = Vector2.zero; // Detiene el movimiento
    //        rb.isKinematic = true; // Desactiva la física para que no caiga
    //        rb.angularVelocity = 0f;

    //        // Ajustar la rotación según la normal de la superficie
    //        Vector2 normal = collision.contacts[0].normal;
    //        float angle = Mathf.Atan2(normal.y, normal.x) * Mathf.Rad2Deg;
    //        transform.rotation = Quaternion.Euler(0, 0, angle - 90);
    //    }

    //    if (!pegado && collision.gameObject.CompareTag("ParedBomba2"))
    //    {
    //        pegado = true;
    //        rb.velocity = Vector2.zero;
    //        rb.isKinematic = true;
    //        rb.angularVelocity = 0f;

    //        Vector2 normal = collision.contacts[0].normal;
    //        float angle = Mathf.Atan2(normal.y, normal.x) * Mathf.Rad2Deg;
    //        transform.rotation = Quaternion.Euler(0, 0, angle - 90);
    //    }
    //}

}

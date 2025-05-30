using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombaPegajosa : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool pegado = false;
    public string tagBomb2 = "Bomba2";
    private AudioSource audioSource;
    public AudioClip sticky;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Buscar un objeto con el tag "Bomba2"
        GameObject bomb2 = GameObject.FindGameObjectWithTag(tagBomb2);

        // Si existe una bomba y se presiona la tecla L
        if (bomb2 != null && (Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.X)))
        {
            // Obtener el componente Explosiones del GameObject
            Explosiones explosiones = bomb2.GetComponent<Explosiones>();
            BombaPegajosa bombaPegajosa = bomb2.GetComponent<BombaPegajosa>();

            // Si el componente existe, ejecutar la explosi�n
            if (explosiones != null && bombaPegajosa != null && pegado)
            {
                explosiones.Explode();
                FindObjectOfType<ColocarBomba>().StartCooldownBomba2();
            }
            else
            {
                Debug.Log("El script Explosiones no est� asignado a la bomba.");
            }
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!pegado && collision.gameObject.CompareTag("Suelo"))
        {
            pegado = true;
            audioSource.clip = sticky;
            audioSource.Play();
            rb.velocity = Vector2.zero; // Detiene el movimiento
            rb.isKinematic = true; // Desactiva la f�sica para que no caiga
            rb.angularVelocity = 0f;

            // Ajustar la rotaci�n seg�n la normal de la superficie
            Vector2 normal = collision.contacts[0].normal;
            float angle = Mathf.Atan2(normal.y, normal.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle - 90);
        }

        if (!pegado && collision.gameObject.CompareTag("ParedBomba2"))
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SaltoJugador : MonoBehaviour
{
    private Rigidbody2D rb2D;

    [Header("Fuerza del Salto")]
    [SerializeField] private float fuerzaDeSalto = 8.5f;

    private bool enSuelo = false;
    private movimientoJugador movimiento;
    public float reduccion_Salto = 3f;
    private float velocidadOriginal;
    private void Start()
    {
        movimiento = GetComponent<movimientoJugador>();
        rb2D = GetComponent<Rigidbody2D>();
        velocidadOriginal = movimiento.movementSpeed;

}

private void Update()
    {
        // Detecta el input del jugador, solo si está en el suelo
        if (Input.GetButtonDown("Jump") && enSuelo)
        {
            Saltar();

            /*Para que cuando esté en el aire no tenga la libertad de moverse horizontalmente como quiera*/

            movimiento.movementSpeed /= reduccion_Salto;


        }
    }

    private void Saltar()
    {
        // Aplicamos una fuerza instantánea hacia arriba en el Rigidbody2D

        rb2D.AddForce(Vector2.up * fuerzaDeSalto, ForceMode2D.Impulse);

        
    }

    // Detecta si el jugador está tocando el suelo (con el Collider2D)
    private void OnCollisionStay2D(Collision2D col)
{
    // Comprobamos si sigue tocando el suelo
    if (col.gameObject.CompareTag("Suelo"))
    {
        foreach (ContactPoint2D contacto in col.contacts)
        {
            if (contacto.normal.y > 0.5f) // Si la normal indica suelo
            {
                enSuelo = true;
                movimiento.movementSpeed = velocidadOriginal;
                return;
            }
        }
    }
}

    private void OnCollisionExit2D(Collision2D col)
    {
        // Cuando el jugador deje de tocar el suelo, ya no podrá saltar
        if (col.gameObject.CompareTag("Suelo"))
        {
            enSuelo = false;
        }
    }
}

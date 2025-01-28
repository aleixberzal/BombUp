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
        // Detecta el input del jugador, solo si est� en el suelo
        if (Input.GetButtonDown("Jump") && enSuelo)
        {
            Saltar();

            /*Para que cuando est� en el aire no tenga la libertad de moverse horizontalmente como quiera*/

            movimiento.movementSpeed /= reduccion_Salto;


        }
    }

    private void Saltar()
    {
        // Aplicamos una fuerza instant�nea hacia arriba en el Rigidbody2D

        rb2D.AddForce(Vector2.up * fuerzaDeSalto, ForceMode2D.Impulse);

        
    }

    // Detecta si el jugador est� tocando el suelo (con el Collider2D)
    private void OnCollisionEnter2D(Collision2D col)
    {
        // Verificamos si el jugador toca un objeto con la etiqueta 
        if (col.gameObject.CompareTag("Suelo"))
        {
            enSuelo = true;

            /*Tenemos que restaurar la velocidad despu�s de cada salto, una vez toque el suelo*/

            movimiento.movementSpeed = velocidadOriginal;
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        // Cuando el jugador deje de tocar el suelo, ya no podr� saltar
        if (col.gameObject.CompareTag("Suelo"))
        {
            enSuelo = false;
        }
    }
}

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

    [Header("Detección de suelo")]
    public Transform groundCheckLeft;  // Punt esquerre
    public Transform groundCheckRight; // Punt dret
    public float groundCheckRadius = 0.2f; // Empty Object als peus del jugador
    public LayerMask groundLayer; // Només la capa del terra

    private void Start()
    {
        movimiento = GetComponent<movimientoJugador>();
        rb2D = GetComponent<Rigidbody2D>();
        velocidadOriginal = movimiento.movementSpeed;
    }

    private void Update()
    {
        // Raycast per detectar si està tocant el terra
        enSuelo = Physics2D.Raycast(groundCheckLeft.position, Vector2.down, groundCheckRadius, groundLayer) ||
              Physics2D.Raycast(groundCheckRight.position, Vector2.down, groundCheckRadius, groundLayer);


        // Detecta el input del jugador, només si està en el terra
        if (Input.GetButtonDown("Jump") && enSuelo)
        {
            Saltar();

            // Redueix la velocitat mentre està a l'aire
            movimiento.movementSpeed /= reduccion_Salto;
        }
    }

    private void Saltar()
    {
        // Aplicar una força instantània cap amunt
        rb2D.velocity = new Vector2(rb2D.velocity.x, fuerzaDeSalto);
    }
}

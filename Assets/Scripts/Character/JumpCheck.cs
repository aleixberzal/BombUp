using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SaltoJugador : MonoBehaviour
{
    [SerializeField] private RaycastSuelo raycast;
    private Rigidbody2D rb2D;

    [Header("Fuerza del Salto")]
    [SerializeField] private float fuerzaDeSalto = 8.5f;


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
        // Detecta el input del jugador, només si està en el terra
        if (Input.GetButtonDown("Jump") && raycast.enSuelo)
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

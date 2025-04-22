using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class movimientoJugador : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    [SerializeField] private RaycastSuelo raycast;
    private Rigidbody2D rb2D;
    //public Transform playerTransform;
    //private Vector3 lastPosition;

    [Header("Movimiento")]
    private float movimientoHorizontal = 0f;
    /*Creamos las variables públicas para ir comprobando le movimiento en tiempo real*/
    [SerializeField] public float movementSpeed = 10f; 
    [SerializeField] public float fuerzaControl = 30f;
    [SerializeField] public float fuerzaAire = 2f;
    [SerializeField] public bool usarSuavizado = true;
    [SerializeField] private ParticleSystem particulas;
    //[SerializeField] private ParticleSystem particulasAire;
    /*No funciona ahora mismo, pero es una barra para ajustar la aceleración y desaceleración*/
    [Range(0f, 1f)][SerializeField] public float smoothingFactor = 0.9f; 

    private bool mirandoDerecha = true;

    private void Start()
    {
        // Referencia al Rigidbody2D
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        //lastPosition = playerTransform.position;
    }

    private void Update()
    {
        // Detecta la entrada horizontal del jugador (-1 para izquierda, 1 para derecha)
        movimientoHorizontal = Input.GetAxisRaw("Horizontal");
        if (raycast.enSuelo)
        {
            particulas.Play();
        }
        //else
        //{
        //    Vector3 movementDirection = playerTransform.position - lastPosition;

        //    if (movementDirection.sqrMagnitude > 0.001f)
        //    {
        //        // Opcional: ignorar la altura
        //        movementDirection.y = 0;

        //        // Rota el sistema de partículas en la dirección del movimiento
        //        particulasAire.transform.rotation = Quaternion.LookRotation(movementDirection);
        //    }
        //    lastPosition = playerTransform.position;
        //}
    }

    private void FixedUpdate()
    {
        if (movimientoHorizontal != 0)
        {
            /*Llamamos a la función para movernos en caso de que detecte un input de movmiento horizontal*/

            AplicarFuerzaMovimiento(movimientoHorizontal);
        }
        else
        {
            /*En caso de no detectar ningún movimiento horizontal frenamos
             (porque al estar usando fuerzas y no velocidad el inpulso continuaría...)*/
            DetenerMovimiento();
            
        }

        if (usarSuavizado && movimientoHorizontal == 0)
        {
            /*No funcional*/
            //AplicarSuavizado();
        }
    }

    private void AplicarFuerzaMovimiento(float direccion)
    {
        if (movimientoHorizontal != 0 )
        {

            if (animator != null)
            {
                animator.ResetTrigger("iddleTrigger");
                animator.SetTrigger("runTrigger");
            }
        }


        float velocidadActual = rb2D.velocity.x;
        float velocidadDeseada = direccion * movementSpeed;
        float diferenciaVelocidad = velocidadDeseada - velocidadActual;
        Vector2 fuerza;
        if (raycast.enSuelo)
        {
            fuerza = new Vector2(diferenciaVelocidad * fuerzaControl, 0);
        } else
        {
            fuerza = new Vector2(diferenciaVelocidad * fuerzaAire, 0);
        }
        rb2D.AddForce(fuerza, ForceMode2D.Force); // Mantén ForceMode2D.Force para control preciso



        if (direccion > 0 && !mirandoDerecha)
        {
            Girar();
        }
        else if (direccion < 0 && mirandoDerecha)
        {
            Girar();
        }

        
    }

    private void AplicarSuavizado()
    {
        
        Vector2 velocidadActual = rb2D.velocity;
        velocidadActual.x *= smoothingFactor; 
        rb2D.velocity = velocidadActual;
    }

    private void DetenerMovimiento()
    {
        if(movimientoHorizontal == 0 && rb2D.velocity.y == 0)
        {
            if (animator != null)
            {
                animator.ResetTrigger("runTrigger");
                animator.SetTrigger("iddleTrigger");
            }
        }
       
        /*Le decimos que la velocidad de nuestro personaje horizonalmente sea 0*/
        rb2D.velocity = new Vector2(rb2D.velocity.x, rb2D.velocity.y); // Reduce velocidad gradualmente
    }

    private void Girar()
    {
        mirandoDerecha = !mirandoDerecha;
        spriteRenderer.flipX = !spriteRenderer.flipX;

    }
}

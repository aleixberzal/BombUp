using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosiones : MonoBehaviour
{
    [SerializeField] float radius = 10f; // Radio de la explosión
    [SerializeField] float force = 100f; // Fuerza de la explosión
    [SerializeField] ContactFilter2D contactFilter; // Filtro de contacto para 2D
    [SerializeField] Collider2D[] affectedColliders = new Collider2D[25]; // Arreglo para almacenar los colliders afectados

    MainCamera cameraRef = null;

    // Método que maneja la explosión
    public void Explode()
    {
        int numColliders = Physics2D.OverlapCircle(transform.position, radius, contactFilter, affectedColliders);

        if (numColliders > 0)
        {
            for (int i = 0; i < numColliders; i++)
            {
                // Primero aplica la fuerza a los Rigidbodies dentro del rango
                if (affectedColliders[i].gameObject.TryGetComponent(out Rigidbody2D rb))
                {
                    // Calcula la dirección de la fuerza hacia fuera de la bomba
                    Vector2 forceDirection = (rb.transform.position - transform.position).normalized;
                    rb.AddForce(forceDirection * force, ForceMode2D.Impulse);

                    // Agregar efecto de sacudida de cámara si es necesario
                    if (cameraRef != null)
                    {
                        cameraRef.Shake(1f, 1f);
                    }
                }

                // Destruye plataformas con el script BreakableFloor
                if (affectedColliders[i].gameObject.TryGetComponent(out BreakableFloor breakableFloor))
                {
                    breakableFloor.DestroyPlatform();  // Llamamos al método de destrucción en BreakableFloor
                }
            }

            Destroy(gameObject);
        }
    }

    void Start()
    {
        GameObject cam = GameObject.Find("Main Camera");
        if (cam != null)
        {
            cameraRef = cam.GetComponent<MainCamera>();
        }
    }
}

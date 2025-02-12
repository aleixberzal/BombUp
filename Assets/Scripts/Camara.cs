using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Transform player;

    // Posici�n horizontal (X) y de profundidad (Z) fijas
    public float fixedX = 0f;
    public float fixedZ = -10f;

    // Velocidad para suavizar el movimiento vertical de la c�mara
    public float smoothSpeed = 0.125f;

    void LateUpdate()
    {
        // Construimos la posici�n deseada manteniendo X y Z fijos y usando el Y del jugador
        Vector3 desiredPosition = new Vector3(fixedX, player.position.y, fixedZ);

        // Suavizamos el movimiento para que no sea brusco
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Actualizamos la posici�n de la c�mara
        transform.position = smoothedPosition;
    }
}

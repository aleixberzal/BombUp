using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Transform player;

    // Posición horizontal (X) y de profundidad (Z) fijas
    public float fixedX = 0f;
    public float fixedZ = -10f;

    // Velocidad para suavizar el movimiento vertical de la cámara
    public float smoothSpeed = 0.125f;

    private float shakeDuration = 0.0f;
    private float shakeMagnitude = 1.0f;

    private Vector3 shakeOffset = Vector3.zero;


    void Start()
    {
        // Forzar una relación de aspecto 16:9 (1920x1080)
        float aspectRatio = 16f / 9f;
        Camera.main.aspect = aspectRatio;
    }

    void LateUpdate()
    {
        // Construimos la posición deseada manteniendo X y Z fijos y usando el Y del jugador
        Vector3 desiredPosition = new Vector3(fixedX, player.position.y, fixedZ);

        // Suavizamos el movimiento para que no sea brusco
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        if (shakeDuration > 0){
            float x = Random.Range(-.1f, .1f) * shakeMagnitude;
            float y = Random.Range(-.1f, .1f) * shakeMagnitude;

            shakeOffset = new Vector3(x, y, 0);


            shakeDuration -= Time.deltaTime;
            if (shakeDuration < .8f){
                shakeDuration = 0.0f;
            }

            // Actualizamos la posición de la cámara
            transform.position = smoothedPosition + shakeOffset;
        }
        else
        {
            // Actualizamos la posición de la cámara
            transform.position = smoothedPosition;
        }


        
    }

    public void Shake(float duration, float magnitude)
    {
        shakeDuration = duration;
        shakeMagnitude = magnitude;

    }
 }

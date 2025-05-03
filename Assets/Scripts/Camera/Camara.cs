using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Transform player;

    public float fixedX = 0f;
    public float fixedZ = -10f;
    public float smoothSpeed = 0.125f;
    public float verticalOffset = 2f;
    private float shakeDuration = 0.0f;
    private float shakeMagnitude = 1.0f;

    private Vector3 shakeOffset = Vector3.zero;


    void Start()
    {
        float aspectRatio = 16f / 9f;
        Camera.main.aspect = aspectRatio;
    }

    void LateUpdate()
    {
        Vector3 desiredPosition = new Vector3(fixedX, player.position.y + verticalOffset, fixedZ);
        desiredPosition.y = Mathf.Min(desiredPosition.y, 141f);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        if (shakeDuration > 0)
        {
            float x = Random.Range(-.1f, .1f) * shakeMagnitude;
            float y = Random.Range(-.1f, .1f) * shakeMagnitude;
            shakeOffset = new Vector3(x, y, 0);
            shakeDuration -= Time.deltaTime;

            if (shakeDuration < .8f)
            {
                shakeDuration = 0.0f;
            }

            transform.position = smoothedPosition + shakeOffset;
        }
        else
        {
            transform.position = smoothedPosition;
        }
    }

    public void Shake(float duration, float magnitude)
    {
        shakeDuration = duration;
        shakeMagnitude = magnitude;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Progress : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform player;
    public Transform meta;
    private float startHeight;
    private float finalHeight;
    private float actualHeight;
    private float progreso;
    public TMP_Text progressText;
    void Start()
    {
        if (player != null)
        {
            startHeight = player.position.y;
            finalHeight = meta.position.y;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            actualHeight = player.position.y;
            progreso = (actualHeight - startHeight) / (finalHeight - startHeight) * 100;
            progreso = Mathf.Clamp(progreso, 0, 100); // Asegura que no pase del 100%

            progressText.text = progreso.ToString("F1") + "%";
        }
        
    }
}

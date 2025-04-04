using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Sprite[] spritesDinamita;
    public float tiempoCambio = 1f; // Tiempo entre cambios de imagen

    private SpriteRenderer spriteRenderer;
    private int indiceSprite = 0;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(AnimacionDinamita());
    }
    IEnumerator AnimacionDinamita()
    {
        while (indiceSprite < spritesDinamita.Length)
        {
            spriteRenderer.sprite = spritesDinamita[indiceSprite]; // Cambia el sprite
            indiceSprite++;
            yield return new WaitForSeconds(tiempoCambio); // Espera antes de cambiar al siguiente sprite
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

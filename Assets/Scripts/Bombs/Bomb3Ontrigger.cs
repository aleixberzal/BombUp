using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb3Ontrigger : MonoBehaviour
{
    public FireworkBomb fireworkBomb;
    public bool aa;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Suelo") || collision.CompareTag("ParedBomba2"))
        {
            fireworkBomb.Ontrigger = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Suelo"))
        {
            fireworkBomb.Ontrigger = false;
        }
    }

}

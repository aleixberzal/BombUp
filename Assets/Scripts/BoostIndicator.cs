using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BoostIndicator : MonoBehaviour
{
    [SerializeField] private ColocarBomba colocarBomba;
    private Transform bomb1;
    private Transform bomb2;
    public GameObject arrow1;
    public GameObject arrow2;
    public bool bomb1OnTrigger;
    public bool bomb2OnTrigger;


    // Start is called before the first frame update
    void Start()
    {
        
    }
    

    // Update is called once per frame
    void Update()
    {
        if (bomb1OnTrigger)
        {
            bomb1 = colocarBomba.bomba1.transform;
            Vector2 direction = (bomb1.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            arrow1.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            arrow1.transform.localScale = Vector3.one;
        }
        if (bomb2OnTrigger)
        {
            bomb2 = colocarBomba.bomba2.transform;
            Vector2 direction = (bomb2.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            arrow2.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            arrow2.transform.localScale = Vector3.one;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bomb1Collider"))

        {
            arrow1.SetActive(true);
            bomb1OnTrigger = true;
        }
        if (collision.CompareTag("Bomb2Collider"))

        {
            arrow2.SetActive(true);
            bomb2OnTrigger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Bomb1Collider"))
        {
            bomb1OnTrigger = false;
            arrow1.SetActive(false);

        }
        if (collision.CompareTag("Bomb2Collider"))
        {
            bomb2OnTrigger = false;
            arrow2.SetActive(false);

        }
    }
}

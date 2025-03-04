using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BoostIndicator : MonoBehaviour
{
    public Transform bomb1;  // The bomb's transform
    public ColocarBomba ColocarBomba;
    public GameObject arrow1;
    public bool bomb1Active;


    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    

    // Update is called once per frame
    void Update()
    {
        bomb1 = ColocarBomba.bomba1.transform;
        
        

            
       

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Bomba1"))
        {
            arrow1.SetActive(true);
            Vector2 direction = (bomb1.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            arrow1.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            arrow1.transform.localScale = Vector3.one;
        }
    }

}

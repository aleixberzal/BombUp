using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosiones : MonoBehaviour
{
    [SerializeField] float radius = 10;
    [SerializeField] float force = 100;
    [SerializeField] ContactFilter2D contactFilter;
    [SerializeField] Collider2D[] affectedColliders = new Collider2D[25];

    MainCamera cameraRef = null;

    public void Explode()
    {
        int numColliders = Physics2D.OverlapCircle(transform.position, radius, contactFilter, affectedColliders);

        if (numColliders > 0)
        {
            for (int i = 0; i < numColliders; i++)
            {
                if (affectedColliders[i].gameObject.TryGetComponent(out Rigidbody2D rb))
                {
                    Vector2 forceDirection = (rb.transform.position - transform.position).normalized;
                    rb.AddForce(forceDirection * force, ForceMode2D.Impulse);
                    if (cameraRef != null)
                    {
                        cameraRef.Shake(1f, 1f);
                    }
                    Destroy(gameObject);
                }
            }
        }
    }

// Start is called before the first frame update
void Start()
    {
        GameObject cam = GameObject.Find("Main Camera");
        if(cam != null) {
            cameraRef = cam.GetComponent<MainCamera>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

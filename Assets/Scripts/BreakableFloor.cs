using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableFloor : MonoBehaviour
{
    public void DestroyPlatform()
    {
        Destroy(gameObject);
    }
}

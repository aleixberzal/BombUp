using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    public void DestroyPlatform()
    {
        Destroy(gameObject);
    }
}

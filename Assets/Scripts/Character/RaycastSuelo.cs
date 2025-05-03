using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastSuelo : MonoBehaviour
{
    [SerializeField] public bool enSuelo = false;

    public Transform groundCheckLeft;
    public Transform groundCheckRight;
    public Transform groundCheckCenter;
    public float groundCheckRadius = 0.2f; // Empty Object als peus del jugador
    public LayerMask groundLayer; // Només la capa del terra

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enSuelo = Physics2D.Raycast(groundCheckLeft.position, Vector2.down, groundCheckRadius, groundLayer) ||
             Physics2D.Raycast(groundCheckRight.position, Vector2.down, groundCheckRadius, groundLayer) ||
             Physics2D.Raycast(groundCheckCenter.position, Vector2.down, groundCheckRadius, groundLayer);
    }
}

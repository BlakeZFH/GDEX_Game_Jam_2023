using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    [HideInInspector]
    public Vector3 movement;
    [HideInInspector]
    public float lastHorizontalVector;
    [HideInInspector]
    public float lastVerticalVector;

    [SerializeField] float speed = 3f;

    Animate animate;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        movement = new Vector3();
        animate = GetComponent<Animate>();
    }

    private void Start()
    {
        lastHorizontalVector = -1f;
        lastVerticalVector = -1f;
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.x != 0)
        {
            lastHorizontalVector = movement.x;
        }
        if(movement.y != 0)
        {
            lastVerticalVector = movement.y;
        }

        animate.horizontal = movement.x;

        movement *= speed;

        rb.velocity = movement;
    }
}

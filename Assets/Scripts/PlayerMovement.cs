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
    public float lastHorizontalDeCoupledVector;
    [HideInInspector]
    public float lastVerticalDeCoupledVector;

    [HideInInspector]
    public float lastHorizontalCoupledVector;
    [HideInInspector]
    public float lastVerticalCoupledVector;

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
        lastHorizontalDeCoupledVector = -1f;
        lastVerticalDeCoupledVector = 1f;

        lastHorizontalCoupledVector = -1f;
        lastVerticalCoupledVector = -1f;
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if(movement.x != 0 || movement.y != 0)
        {
            lastHorizontalCoupledVector = movement.x;
            lastVerticalCoupledVector = movement.y;
        }

        if (movement.x != 0)
        {
            lastHorizontalDeCoupledVector = movement.x;
        }
        if(movement.y != 0)
        {
            lastVerticalDeCoupledVector = movement.y;
        }

        animate.horizontal = movement.x;

        movement *= speed;

        rb.velocity = movement;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 3.5f;
    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float movementX = Input.GetAxis("Horizontal");
        float movementY = Input.GetAxis("Vertical");

        movement = new Vector2(movementX, movementY);

        animator.SetFloat("MovementX", movementX);
        animator.SetFloat("MovementY", movementY);

        if (movementX != 0 && movementY != 0)
        {
            animator.SetFloat("LastX", movementX);
            animator.SetFloat("LastY", movementY);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
    }
}

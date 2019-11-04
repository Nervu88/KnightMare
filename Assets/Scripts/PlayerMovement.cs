using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;
    private float velocityValue;
    public Animator thisAnim;
    public Rigidbody2D rb;

    Vector2 movement;
    Vector2 velocity;

    void Start()
    {
        thisAnim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        // Input hommat

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        velocityValue = movement.x + movement.y;
    }

    void FixedUpdate()
    {
        // Movement jutut

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        //Animaation käytös 0 = idleAnim -1 +1 on isMoving

        if (velocityValue > 0)
        {
            thisAnim.SetFloat("Velocity", 1);

        } else if (velocityValue < 0)
        {
            thisAnim.SetFloat("Velocity", 1);
        } else
        {
            thisAnim.SetFloat("Velocity", 0);
        }


    }
}

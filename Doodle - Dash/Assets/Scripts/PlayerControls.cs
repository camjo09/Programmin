using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{


    [Header("Physics")]
    public float gravity = 20f;
    [Header("Movement Variables")]
    public float speed = 5f;
    public Vector2 moveDirection;
    public Rigidbody2D rb;
    public float jumpSpeed = 10f;
    int jumpCount = 1;


    void Start()
    {

    }

    void Update()
    {

        Vector3 vel = rb.velocity;
        vel.x = speed;
        rb.velocity = vel;


        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 3)
        {
            rb.AddForce(transform.up * jumpSpeed, ForceMode2D.Impulse);
            jumpCount++;
        }


    //Need to reset jump count when touching ground

    }
    // Cleans Code: CTRL + K, CTRL + D
    private void FixedUpdate()
    {

    }
}


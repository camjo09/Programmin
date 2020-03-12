using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{

    #region Movement variables
    [Header("Physics")]
    public float gravity = 20f;
    [Header("Movement Variables")]
    public float speed = 5f;
    public float jumpSpeed = 10f;
    public int jumpCount = 0;
    public int extraJumps = 1;
    public Vector2 moveDirection;
    public Rigidbody2D rb;
    public bool isGrounded;
    public LayerMask groundLayer;
    private Collider2D playerCollider;
    #endregion
    #region Player Stats
    public float health;
    public float enemyDammage;
    public bool playerDead;
    public LayerMask hazardsLayer;


    #endregion
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        #region Movement functions
        if (!playerDead)
        {
            isGrounded = Physics2D.IsTouchingLayers(playerCollider, groundLayer);

            if (isGrounded)
            {
                jumpCount = 0;
            }


            // The constant rightwards movements
            Vector3 vel = rb.velocity;
            vel.x = speed;
            rb.velocity = vel;


            if (Input.GetKeyDown(KeyCode.Space) && jumpCount < extraJumps)
            {
                Jump();
            }

            // Jump function

            void Jump()
            {
                rb.AddForce(transform.up * jumpSpeed, ForceMode2D.Impulse);
                jumpCount++;
            }
        }
        else
        {
            //OOPS YOU DIED
        }
        #endregion

        #region Player Stats Functions
        playerDead = Physics2D.IsTouchingLayers(playerCollider, hazardsLayer);




        #endregion
    }
    // Cleans Code: CTRL + K, CTRL + D
}


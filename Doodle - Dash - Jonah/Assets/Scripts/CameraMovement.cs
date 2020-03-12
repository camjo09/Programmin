using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 5f;
    public PlayerControls playerDead;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerDead)
        {
            Vector3 vel = rb.velocity;
            vel.x = speed;
            rb.velocity = vel;
        }
        else if(playerDead)
        {
            
        }
    }
}

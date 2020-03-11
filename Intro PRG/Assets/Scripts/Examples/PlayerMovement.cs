using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Game Systems/RPG/Player/Movement")]
[RequireComponent(typeof(CharacterController))]


public class PlayerMovement : MonoBehaviour
{
    [Header("Physics")]
    public CharacterController controller;
    public float gravity = 20f;
    [Header("Movement Variables")]
    public float speed = 5f;
    public float sprintspeed = 10f;
    public float crouchspeed = 2.5f;
    public float jumpSpeed = 8f;                        
    public Vector3 moveDirection;
    void Start()
    {
        controller = this.gameObject.GetComponent<CharacterController>();
    }
  
    
    #region Update Function


    void Update()
    {
        if (controller.isGrounded && !Stats.BaseStats.isDead)
        {
            moveDirection = transform.TransformDirection(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

        if(Input.GetKey(KeyCode.LeftShift))
        {
            speed = sprintspeed;
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            speed = crouchspeed;
        }
        else
        {
            speed = 5f;
        }
    }
    #endregion
}

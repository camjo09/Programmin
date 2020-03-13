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
    public Vector3 moveD;
    public static Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();
    [System.Serializable]
    public struct PlayerInputs
    {
        public KeyCode Forward;
        public KeyCode Left;
        public KeyCode Right;
        public KeyCode Backwards;
        public KeyCode Jump;
        public KeyCode Sprint;
        public KeyCode Crouch;
    }
    public PlayerInputs playerInput;

    void Start()
    {
        playerInput.Forward = KeybindManager.keys["Forward"];
        playerInput.Left = KeybindManager.keys["Left"];
        playerInput.Right = KeybindManager.keys["Right"];
        playerInput.Backwards = KeybindManager.keys["Backwards"];
        playerInput.Jump = KeybindManager.keys["Jump"];
        playerInput.Sprint = KeybindManager.keys["Sprint"];
        playerInput.Crouch = KeybindManager.keys["Crouch"];

        controller = this.gameObject.GetComponent<CharacterController>();
    }
  
    
    #region Update Function


    void Update()
    {              
        if (controller.isGrounded && !Stats.BaseStats.isDead)
        {
            //Speed
            if (Input.GetKeyDown(keys["Sprint"]))
            {
                Debug.Log("Sprint");
            }
            if (Input.GetKeyDown(keys["Crouch"]))
            {
                Debug.Log("Crouch");
            }

            //Direction
            if (Input.GetKeyDown(keys["Forward"]))
            {
                Debug.Log("Up");
                moveD.z = 1;
            }
            if (Input.GetKeyDown(keys["Left"]))
            {
                Debug.Log("Left");
            }
            if (Input.GetKeyDown(keys["Right"]))
            {
                Debug.Log("Right");
            }
            if (Input.GetKeyDown(keys["Backwards"]))
            {
                Debug.Log("Backwards");
                moveD.z = -1;

            }

            moveDirection = transform.TransformDirection(moveD);
            moveDirection *= speed;

            if (Input.GetKeyDown(keys["Jump"]))
            {
                Debug.Log("Jump");
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

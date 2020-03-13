using UnityEngine;




    [AddComponentMenu("RPG/Player/Movement")]
    [RequireComponent(typeof(CharacterController))]
    public class Movement : MonoBehaviour
    {
        [Header("Speed Vars")]
        //Value Variables 
        public float moveSpeed = 5;
        public float walkSpeed = 5;
        public float runSpeed = 10;
        public float crouchSpeed = 2.5f; 
        public float jumpSpeed = 10;
        private float _gravity = 20;
        public CharacterController charC;
        //Struct - Contains Multiple Variables (eg...3 floats)
        public Vector3 _moveDir;
        //Reference Variable

        private void Start()
        {

        }
        private void Update()
        {
            Move();
        }
        private void Move()
        {
            //if we are on the ground
            if (charC.isGrounded)
            {
                //set speed
                if (Input.GetButton("Sprint"))
                {
                    moveSpeed = runSpeed;
                }
                
                else if (Input.GetButton("Crouch"))
                {
                    moveSpeed = crouchSpeed;
                }
                else
                {
                    moveSpeed = walkSpeed;
                }
                //calculate movement direction based off inputs
             
                _moveDir = transform.TransformDirection(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) );
                _moveDir *= moveSpeed;
                if (Input.GetButton("Jump"))
                {
                    _moveDir.y = jumpSpeed;
                }
            }
            //Regardless if we are grounded or not
            //apply gravity
            _moveDir.y -= _gravity * Time.deltaTime;
            //apply movement
            charC.Move(_moveDir * Time.deltaTime);
        }
    }



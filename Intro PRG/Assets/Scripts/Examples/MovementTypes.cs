using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTypes : MonoBehaviour
{
    [Header("VALUE VARIABLES")]
    public int speed = 5;
    [Header("Types of Movement")]
    public bool pos;
    public bool translate, addForce, velocity, charController;
  
    [Header("REFERENCE VARIABLES"), Space(50)]
    public Rigidbody rb;
    public CharacterController controller;
    void Update() 
    {
        //single line comment

        /*
        BLOCK
        COMMENT
         */
         /*
         Boolean is true or false
        Variables of bools defualt start false
        
        in an if statement these are ways you can ask if it is 
        TRUE
        if(pos == true)
        if(pos)

        FALSE
        if(pos == false)
        if(!pos)
         */
        if(pos)
        {
            //move our position forward on the Z by speed 
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if(translate)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        if(addForce)
        {
            rb.AddForce(transform.forward * speed);
        }
        if(velocity)
        {
            rb.velocity = transform.forward * speed;
        }
        if(charController)
        {
            controller.Move(transform.forward * speed * Time.deltaTime);
        }
    }
}

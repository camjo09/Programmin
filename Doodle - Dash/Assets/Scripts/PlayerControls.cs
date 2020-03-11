using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{


    [Header("Physics")]
    public CharacterController controller;
    public float gravity = 20f;
    [Header("Movement Variables")]
    public float speed = 5f;
    public Vector2 moveDirection;



    void Start()
    {
        controller = this.gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

    }
}

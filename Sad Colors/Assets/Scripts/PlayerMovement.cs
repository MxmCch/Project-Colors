using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Interact _Interact;
    public CharacterController _CharacterController;
    public float speed = 12f;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask _GroundMask;

    Vector3 velocity;
    bool isGrounded;
    public float x;
    public float z;

    void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, _GroundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 20f;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 12f;
        }

        if (!_Interact.decisionActive)
        {
            x = Input.GetAxis("Horizontal");
            z = Input.GetAxis("Vertical");   
        }
    
        Vector3 move = transform.right *x+transform.forward * z;
        _CharacterController.Move(move*speed*Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        _CharacterController.Move(velocity * Time.deltaTime);
    }
}

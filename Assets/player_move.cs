using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move : MonoBehaviour
{
    public CharacterController controller;
    public Transform player_model;

    private float speed = 4f;
    private float gravity = -9.81f * 2;
    private float jumpHeight = 2f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;

    bool isGrounded;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //checking if we hit the ground to reset our falling velocity, otherwise we will fall faster the next time
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        float look_x = Input.GetAxis("Horizontal");
        float look_z = Input.GetAxis("Vertical");

        //right is the red Axis, foward is the blue axis
        Vector3 move = (transform.right * x + transform.forward * z).normalized;
        
        if (move != Vector3.zero)
        {
            Vector3 look = (transform.right * look_x + transform.forward * look_z).normalized;
            if (look != Vector3.zero)
            {
                player_model.forward = look;
            }  
        }

        controller.Move(move * speed * Time.deltaTime);

        //check if the player is on the ground so he can jump
        if (Input.GetButton("Jump") && isGrounded)
        {
            //the equation for jumping
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
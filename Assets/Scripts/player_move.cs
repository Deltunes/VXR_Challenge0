using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move : MonoBehaviour
{
    public CharacterController controller;
    public Transform player_model;

    [SerializeField] float speed = 4f;
    private float gravity = -9.81f * 2;
    private float jumpHeight = 1.5f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;

    bool isGrounded;

    private Vector3 lastLookDir = Vector3.forward;
    private Vector3 candidateLookDir;
    private float lookTimer;
    private float commitDelay = 0.05f;

    [SerializeField] Animator playerAnimator;

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

        Vector3 move = (transform.right * x + transform.forward * z).normalized;

        bool isDiagonal = x != 0 && z != 0;
        Vector3 rawLook = move;

        if (isDiagonal)
        {
            lastLookDir = rawLook;
            lookTimer = 0f;
        }
        else if (rawLook != Vector3.zero)
        {
            if (rawLook == candidateLookDir)
            {
                lookTimer += Time.deltaTime;
                if (lookTimer >= commitDelay)
                {
                    lastLookDir = rawLook;
                }
            }
            else
            {
                candidateLookDir = rawLook;
                lookTimer = 0f;
            }
        }
        else
        {
            lookTimer = 0f;
        }

        // Animation
        if (move == Vector3.zero)
        {
            playerAnimator.Play("Armature|Idle");
        }
        else
        {
            playerAnimator.Play("Armature|WalkCycle");
        }

        if (GameManager.dialogueActive == false)
        {
            player_model.forward = lastLookDir;
            controller.Move(move * speed * Time.deltaTime);

            if (Input.GetButton("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);
        }
    }
}
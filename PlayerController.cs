using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private CharacterInput controls; // lets us access the CharacterInput input system we made
    private Vector3 velocity; // to hold player's velocity
    private Vector2 move; // hold player's move

    private CharacterController controller; // CharacterController called controller

    public float moveSpeed = 10f; 
    public float jumpHeight = 2.5f; // player movement stuff
    public float gravity = -9.81f; 

    public Transform ground;
    public float distanceToGround = 0.4f;
    public LayerMask groundMask;

    void Awake()
    {
        controls = new CharacterInput();
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        PlayerMovement();
        Grav();
        Jump();
    }

    private void Grav()
    {
        if (isGrounded() && velocity.y < 0) // if player is on ground and isn't moving
        {
            velocity.y = -2f; // velocity into ground to stay there
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private bool isGrounded()
    {
        return Physics.CheckSphere(ground.position, distanceToGround, groundMask); // checks if player is on ground
    }

    private void PlayerMovement()
    {
        move = controls.Player.Movement.ReadValue<Vector2>(); // movement input into move variable

        Vector3 movement = (move.y * transform.forward) + (move.x * transform.right); // Vector2 input into direction

        controller.Move(movement * moveSpeed * Time.deltaTime); // applying movement
    }

    private void Jump()
    {
        if (controls.Player.Jump.triggered && isGrounded()) 
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    void OnEnable()
    {
        controls.Enable();
    }

    void OnDisable()
    {
        controls.Disable();
    }
}

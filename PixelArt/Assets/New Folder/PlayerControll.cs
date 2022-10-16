using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControll : MonoBehaviour
{
    [Space]

    private PlayerInput input;
    private InputAction moveInput;
    private InputAction jumpInput;
    private InputAction middleButton;
    private InputAction lookInput;

    [Space]

    public Rigidbody rb;
    public CharacterController characterController;

    [Space]

    public float moveSpeed = 5f;
    public float jumpHeight = 1f;
    public float lookSpeed = 5f;

    [Space]

    public float gravityMultiplier = 2f;
    public const float gravity = -9.81f;

    [Space]

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    [Space]

    private Vector3 move;
    private Vector2 turn;
    [SerializeField]
    private Vector3 velocity;
    private bool isGrounded;

    private void Awake()
    {
        input = new PlayerInput();
    }

    private void OnEnable()
    {
        moveInput = input.Player.Move;
        moveInput.Enable();

        jumpInput = input.Player.Jump;
        jumpInput.Enable();

        middleButton = input.Player.MiddleButton;
        middleButton.Enable();

        lookInput = input.Player.Look;
        lookInput.Enable();
    }

    private void OnDisable()
    {
        moveInput.Disable();
        jumpInput.Disable();
        middleButton.Disable();
        lookInput.Disable();
    }

    void Update()
    {
        // Ground Check
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // Rotation
        if (middleButton.ReadValue<float>() > 0.5)
        {
            turn += lookInput.ReadValue<Vector2>();
            transform.localRotation = Quaternion.Euler(0, turn.x / 10 * lookSpeed, 0);
        }
    }

    private void FixedUpdate()
    {
        // Gorund Stop
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Movement
        move = transform.right * moveInput.ReadValue<Vector2>().x + transform.forward * moveInput.ReadValue<Vector2>().y;
        characterController.Move(move * moveSpeed/100);


        // Jumping
        if (jumpInput.ReadValue<float>() > 0.5 && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity * gravityMultiplier);
        }

        // Gravity        
        velocity.y += gravity * gravityMultiplier / 60;

        characterController.Move(velocity * Time.deltaTime);
    }
}

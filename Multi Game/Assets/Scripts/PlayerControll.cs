using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControll : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed = 5f;
    public Vector2 moveDirection;
    private bool jumped = false;
    public float jumpPower = 5f;

    public Rigidbody bulletRb;
    public Transform tr;
    public float fireCooldown = 1f;
    private bool coolDown = false;
    
    public PlayerInput input;

    private InputAction move;
    private InputAction jump;
    private InputAction fire;

    private void Awake()
    {
        input = new PlayerInput();
    }

    private void OnEnable()
    {
        move = input.Player.Move;
        move.Enable();
        jump = input.Player.Jump;
        jump.Enable();
        fire = input.Player.Fire;
        fire.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
        jump.Disable();
        fire.Disable();
    }

    void Start()
    {
        
    }

    void Update()
    {
        moveDirection = move.ReadValue<Vector2>();
        if (fire.ReadValue<float>() > 0.5 && !coolDown)
        {
            Instantiate(bulletRb,new Vector3(tr.position.x, tr.position.y - 1, tr.position.z),tr.rotation);
            coolDown = true;
        }
        if (fire.ReadValue<float>() < 0.5)
            coolDown = false;
        
        if (jump.ReadValue<float>() < 0.5)
            jumped = false;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(moveDirection.x * moveSpeed, rb.velocity.y, moveDirection.y * moveSpeed);

        if (tr.position.y < 1.1 && jump.ReadValue<float>() > 0.5 && !jumped)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpPower, rb.velocity.x);
            jumped = true;
        }
    }
}

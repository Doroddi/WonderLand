using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement Info")]
    [SerializeField] public float moveSpeed = 7;
    [SerializeField] public bool isFacingRight { get; private set; }


    #region Components
    public Animator anim { get; private set; }

    public Rigidbody2D rb { get; private set; }
    #endregion

    #region States
    public PlayerStateMachine stateMachine { get; private set; }
    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }

    public PlayerJumpState jumpState { get; private set; }
    public PlayerAirState airState { get; private set; }
    #endregion

    [Header("Collision info")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private Transform interactionCheck;
    [SerializeField] private float interactionCheckRadius;
    [SerializeField] private LayerMask groundMask;

    private void Awake()
    {

        stateMachine = new PlayerStateMachine();
        idleState = new PlayerIdleState(this, stateMachine, "isIdle");
        moveState = new PlayerMoveState(this, stateMachine, "isWalking");
        jumpState = new PlayerJumpState(this, stateMachine, "isJumping");
        airState = new PlayerAirState(this, stateMachine, "isJumping");
        isFacingRight = true;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        stateMachine.Initialize(idleState);
    }

    private void Update()
    {
        stateMachine.currentState.Update();

    }

    private void FixedUpdate()
    {
        stateMachine.currentState.FixedUpdate();
    }

    public void SetVelocity(float _xVelocity, float _yVelocity)
    {
        rb.velocity = new Vector2(_xVelocity, _yVelocity);
    }

    public bool IsGrounded() => Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, groundMask);

    public void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0, 180, 0);
    }
    private void OnDrawGizmos()
    {
        // Checking the ground with ray
        Gizmos.DrawLine(
            groundCheck.position,
            new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance)
            );

        // range based checking. using circular range
        Gizmos.DrawSphere(interactionCheck.position, interactionCheckRadius);

    }
}

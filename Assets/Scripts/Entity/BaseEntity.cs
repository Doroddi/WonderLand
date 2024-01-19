using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEntity : MonoBehaviour
{

    #region Components
    public Animator anim { get; private set; }

    public Rigidbody2D rb { get; private set; }
    #endregion

    [Header("Collision info")]
    [SerializeField] protected Transform groundCheck;
    [SerializeField] protected float groundCheckDistance;
    [SerializeField] protected Transform interactionCheck;
    [SerializeField] protected float interactionCheckRadius;
    [SerializeField] protected LayerMask groundMask;

    [SerializeField] protected bool isFacingRight { get; private set; }

    public int facingDir { get; private set; } = 1;

    protected virtual void Awake()
    {

        isFacingRight = true;

    }

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    protected virtual void Update()
    {

    }

    protected virtual void FixedUpdate()
    {

    }

    public bool IsGrounded() => Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, groundMask);

    public void Flip()
    {
        facingDir = facingDir * -1;
        isFacingRight = !isFacingRight;
        transform.Rotate(0, 180, 0);
    }

    public void FlipController(float _x)
    {
        if (_x > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (_x < 0 && isFacingRight)
        {
            Flip();
        }
    }

    public void SetVelocity(float _xVelocity, float _yVelocity)
    {
        rb.velocity = new Vector2(_xVelocity, _yVelocity);
    }

}

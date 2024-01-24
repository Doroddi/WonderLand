using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEntity : MonoBehaviour
{

    #region Components
    public Animator anim { get; private set; }

    public Rigidbody2D rb { get; private set; }
    public BoxCollider2D coll;
    #endregion

    [Header("Collision info")]
    [SerializeField] protected Transform groundCheck;
    [SerializeField] protected float groundCheckDistance;
    [SerializeField] protected Transform interactionCheck;
    [SerializeField] protected float interactionCheckRadius;
    [SerializeField] protected LayerMask groundMask;

    [SerializeField] protected bool isFacingRight { get; private set; }

    [SerializeField] public bool isJump;

    public int facingDir { get; private set; } = 1;

    protected virtual void Awake()
    {

        isFacingRight = true;

    }

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        coll = GetComponent<BoxCollider2D>();
    }

    protected virtual void Update()
    {

    }

    protected virtual void FixedUpdate()
    {

    }

    public bool IsGrounded()
    {

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, 0.15f);

        for (int i = 0; i < colliders.Length; i++)
        {

            if (colliders[i].gameObject.layer.Equals(LayerMask.NameToLayer("Ground")))
            {
                isJump = true;
                return true;
            }
        }
        isJump = false;
        return false;

    }
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

    public void SetVelocity(Vector2 velocity)
    {
        rb.velocity = velocity;
    }

}

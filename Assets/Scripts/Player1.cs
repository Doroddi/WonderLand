using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    private Rigidbody2D rigid;
    private SpriteRenderer sprite;
    private BoxCollider2D coll;

    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashDuration;
    [SerializeField] private float dashTime;
    [SerializeField] private float dashCoolDownTime;
    [SerializeField] private float dashCoolDown;
    private float xInput;

    private bool facingRight = true;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
        dashDuration = 1;
        dashCoolDownTime = 4;
        dashCoolDown = 4;
    }

    private void Update()
    {
        MovementInput();
        Jump();
        DirectionController();
    }

    private void FixedUpdate()
    {
        Movement();
        dashTime -= Time.deltaTime;
        dashCoolDownTime -= Time.deltaTime;
    }

    private void MovementInput()
    {
        xInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Dash();
        }
    }

    private void Movement()
    {
        if (dashTime > 0)
        {
            rigid.velocity = new Vector2(xInput * dashSpeed, rigid.velocity.y);
        }
        else
        {
            rigid.velocity = new Vector2(xInput * moveSpeed, rigid.velocity.y);
        }
    }

    private void Dash()
    {
        if (dashCoolDownTime < 0)
        {
            dashTime = dashDuration;
            dashCoolDownTime = dashCoolDown;
        }
    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void DirectionController()
    {
        if (xInput > 0 && !facingRight)
        {
            Flip();
        }
        else if (xInput < 0 && facingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, groundLayer);
    }

    // 끼임 현상 해결
}
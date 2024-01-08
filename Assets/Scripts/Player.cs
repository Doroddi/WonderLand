using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigid;
    SpriteRenderer sprite;
    BoxCollider2D coll;

    public LayerMask groundLayer;

    public float speed;
    public float jumpForce;
    float x;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        MovementInput();
        Jump();
        flipX();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void MovementInput()
    {
        x = Input.GetAxisRaw("Horizontal");
    }

    private void Movement()
    {

        rigid.velocity = new Vector2(x * speed, rigid.velocity.y);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
    private void flipX()
    {
        if(rigid.velocity.x > 0)
        {
            sprite.flipX = false;
        }else if (rigid.velocity.x < 0)
        {
            sprite.flipX = true;
        }
    }
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, groundLayer);
    }
}
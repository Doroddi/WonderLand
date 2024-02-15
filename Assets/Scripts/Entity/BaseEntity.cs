using System.Collections;
using System.Collections.Generic;
using System.Drawing;
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


    [SerializeField]
    Collider2D prevGO;
    bool nullCheck;

    public Vector2 size;
    public Vector2 LRCheck;

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
        Collider2D[] colliders = Physics2D.OverlapBoxAll(groundCheck.position, size, 0);

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

    public void ActivateGround()
    {
        Vector2 groundCheckY = new Vector2(groundCheck.position.x, groundCheck.position.y);

        RaycastHit2D ground = Physics2D.BoxCast(groundCheckY, size, 0f, Vector2.down, 0.1f, LayerMask.GetMask("Ground"));

        Vector2 groundCheckpoint_1 = new Vector2(groundCheck.position.x + 0.35f, groundCheck.position.y + 0.1f);
        Vector2 groundCheckpoint_2 = new Vector2(groundCheck.position.x - 0.35f, groundCheck.position.y + 0.1f);

        RaycastHit2D groundCheck_1 = Physics2D.Raycast(groundCheckpoint_1, Vector2.up, 0.92f, LayerMask.GetMask("Ground"));
        RaycastHit2D groundCheck_2 = Physics2D.Raycast(groundCheckpoint_2, Vector2.up, 0.92f, LayerMask.GetMask("Ground"));

        /*if (ground && prevGO != ground.collider && prevGO)
        {
            prevGO.isTrigger = true;
        }


        if (ground && (groundCheck_1 || groundCheck_2))
        {
            ground.collider.isTrigger = false;

            prevGO = ground.collider;
        }*/

        if (ground && ground.collider != prevGO)
        {
            if((!groundCheck_1 || groundCheck_1.collider != ground.collider) && (!groundCheck_2 || groundCheck_2.collider != ground.collider))
            {
                prevGO.isTrigger = true;

                ground.collider.isTrigger = false;

                prevGO = ground.collider;
            }
        }

        /*if (ground)
        {
            if (nullCheck && prevGO != ground.collider)
            {
                prevGO.isTrigger = true;

                ground.collider.isTrigger = false;

                prevGO = ground.collider;

                nullCheck = false;
            }
            else
            {
                nullCheck = false;
            }
        }
        else
        {
            nullCheck = true;
        }*/
    }

    public void Flip()
    {
        Debug.Log("flip");
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

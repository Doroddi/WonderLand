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


    Collider2D prevGO;

    public Vector2 size;

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
        Vector2 groundCheckY = new Vector2(groundCheck.position.x, groundCheck.position.y + 0.4f);

        RaycastHit2D[] grounds = Physics2D.RaycastAll(groundCheckY, Vector2.down, 15f, LayerMask.GetMask("Ground"));

        if (grounds.Length > 0 && prevGO != grounds[0].collider && prevGO)
        {
            prevGO.isTrigger = true;

        }

        // Debug.Log(grounds.Length);

        Debug.DrawRay(groundCheck.position, Vector2.down, Color.red);

        if (grounds.Length > 0)
        {
            grounds[0].collider.isTrigger = false;

            prevGO = grounds[0].collider;
        }
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

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(groundCheck.position, size);
    }
}

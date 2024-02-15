using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEditor.Tilemaps;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerState
{
    protected PlayerStateMachine stateMachine;
    protected Player player;

    protected Rigidbody2D rb;

    protected float xInput;
    private string animBoolName;

    protected RaycastHit2D slopeHit;
    protected const float RAY_DISTANCE = 0.1f;



    public PlayerState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName)
    {
        this.player = _player;
        this.stateMachine = _stateMachine;
        this.animBoolName = _animBoolName;
    }

    public virtual void Enter()
    {
        player.anim.SetBool(animBoolName, true);
        rb = player.rb;
    }

    public virtual void Update()
    {
        if (!GameManager.instance.isResume)
        {
            xInput = 0;
            rb.velocity = Vector2.zero;
            return;
        }

        xInput = Input.GetAxisRaw("Horizontal");
        player.FlipController(xInput);

        player.ActivateGround();

        if (player.IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            stateMachine.ChangeState(player.jumpState);
        }

        FreezePosition();

    }

    public virtual void Exit()
    {
        player.anim.SetBool(animBoolName, false);

    }

    public virtual void FixedUpdate()
    {
        if (!player.isJump)
        {
            player.rb.velocity = new Vector2(xInput * player.moveSpeed, player.rb.velocity.y);
            player.anim.SetFloat("yVelocity", player.rb.velocity.y);

            if (rb.velocity.y < 0 && !player.isJump && stateMachine.currentState != player.airState)
            {
                stateMachine.ChangeState(player.airState);
            }
        }
    }
    private void FreezePosition()
    {
        if (xInput == 0)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }


}
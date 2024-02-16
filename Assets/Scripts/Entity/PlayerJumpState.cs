using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerState
{
    private float jumpForce = 5;

    public PlayerJumpState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);

    }

    public override void Exit()
    {
        base.Exit();
    }
    public override void Update()
    {

        base.Update();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();

        Debug.Log(player.rb.velocity.y);

        if (player.jumpingCheck && player.isJump && player.rb.velocity.y < 1.5) 
        {
            stateMachine.ChangeState(player.idleState);
        }
    }

}

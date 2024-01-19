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
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

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

        if (rb.velocity.y < 0)
        {
            stateMachine.ChangeState(player.airState);
        }
    }

}

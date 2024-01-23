using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundedState
{
    public PlayerIdleState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {

    }
    public override void Enter()
    {
        base.Enter();
        rb.constraints = RigidbodyConstraints2D.FreezePositionY;
    }

    public override void Exit()
    {
        base.Exit();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    public override void Update()
    {
        base.Update();


        if (xInput != 0)
        {
            stateMachine.ChangeState(player.moveState);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirState : PlayerState
{
    private float highestPointY;
    public event Action<SavePointManager> onFallingHigh;

    public const float RESETHEIGHT = 5f;
    public PlayerAirState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        if (player.isJumpGame)
        {
            highestPointY = player.transform.position.y;
        }
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
        if (player.isJump)
        {
            CheckJumpHeight(SavePointManager.Instance());
            stateMachine.ChangeState(player.moveState);
        }
    }
    public void CheckJumpHeight(SavePointManager manager)
    {
        if (player.isJumpGame && (highestPointY - player.transform.position.y) > RESETHEIGHT)
        {
            onFallingHigh.Invoke(manager);
        }
    }
}

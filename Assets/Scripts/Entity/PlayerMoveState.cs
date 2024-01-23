using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{

    public PlayerMoveState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (xInput == 0)
        {
            stateMachine.ChangeState(player.idleState);
        }

        FreezePosition();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        player.SetVelocity(AdjustDirectionToSlope() * player.moveSpeed);
    }

    private Vector2 AdjustDirectionToSlope() // 이동 벡터와 경사면과의 각도를 가지고 진행 방향 벡터 구하기
    {
        Vector2 direction = new Vector2();
        slopeHit = Physics2D.Raycast(rb.position, Vector2.down, RAY_DISTANCE, LayerMask.GetMask("Ground"));
        if (slopeHit.collider != null)
        {
            var angle = Vector2.Angle(Vector2.up, slopeHit.normal);
            float rad = Mathf.Deg2Rad * angle;
            direction.x = xInput;
            direction.y = xInput * Mathf.Tan(rad);
        }
        return direction.normalized;
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

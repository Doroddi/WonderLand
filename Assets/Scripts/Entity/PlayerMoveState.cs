using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerState
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

        //  if (Input.GetKeyDown(KeyCode.Space) && player.IsGrounded())
        // {
        //     stateMachine.ChangeState(player.jumpState);
        // }

        //FreezePosition();
    }

    public override void FixedUpdate()
    {
        if(player.IsGrounded()) {
            player.SetVelocity(AdjustDirectionToSlope() * player.moveSpeed);
        }else {
            base.FixedUpdate();

        }

    }

    private Vector2 AdjustDirectionToSlope() // �̵� ���Ϳ� ������� ������ ������ ���� ���� ���� ���ϱ�
    {
        Vector2 direction = new Vector2();
        slopeHit = Physics2D.Raycast(rb.position, Vector2.down, RAY_DISTANCE, LayerMask.GetMask("Ground"));
        if (slopeHit.collider != null)
        {
            var angle = Vector2.Angle(Vector2.up, slopeHit.normal);
            Debug.Log(angle);
            float rad = Mathf.Deg2Rad * angle;
            direction.x = xInput;
            direction.y = xInput * Mathf.Tan(rad);
        }
        return direction.normalized;
    }

    
}

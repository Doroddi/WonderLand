using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    }

    public override void FixedUpdate()
    {

        if (player.isJump)
        {
            player.SetVelocity(AdjustDirectionOnSlope() * player.moveSpeed);
        }
        else
        {
            base.FixedUpdate();
        }
    }

    /*private Vector2 AdjustDirectionOnSlope()
    {
        Vector2 direction = new Vector2();
        slopeHit = Physics2D.Raycast(rb.position, Vector2.down, RAY_DISTANCE, LayerMask.GetMask("Ground"));
        if (slopeHit.collider != null)
        {
            var angle = Vector2.SignedAngle(Vector2.up, slopeHit.normal);
            float rad = Mathf.Deg2Rad * angle;
            Debug.Log(angle);
            direction.x = xInput;
            direction.y = xInput * Mathf.Tan(rad);
        }
        return direction.normalized;
    }*/

    private float CalculateAngleWithSlope(Vector2 point)
    {
        slopeHit = Physics2D.Raycast(point, Vector2.down, RAY_DISTANCE, LayerMask.GetMask("Ground"));

        float angle = Vector2.SignedAngle(Vector2.up, slopeHit.normal);
        Debug.Log(angle);

        return angle;
    }

    private Vector2 AdjustDirectionOnSlope()
    {
        Vector2 direction = new Vector2();

        Vector2 directionCheckpoint_1 = new Vector2(rb.position.x + 0.35f, rb.position.y - 0.85f);
        Vector2 directionCheckpoint_2 = new Vector2(rb.position.x - 0.35f, rb.position.y - 0.85f);

        Debug.DrawRay(directionCheckpoint_1, Vector2.down, Color.red);
        Debug.DrawRay(directionCheckpoint_2, Vector2.down, Color.red);

        float angle_1 = CalculateAngleWithSlope(directionCheckpoint_1);
        float angle_2 = CalculateAngleWithSlope(directionCheckpoint_2);

        float angle = Mathf.Abs(angle_1) >= Mathf.Abs(angle_2) ? angle_1 : angle_2;

        Debug.Log(angle);

        float rad = Mathf.Deg2Rad * angle;

        direction.x = xInput;
        direction.y = xInput * Mathf.Tan(rad);

        return direction.normalized;
    }
}

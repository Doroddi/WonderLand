using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slope : MonoBehaviour
{

    [SerializeField] private float maxSlopeAngle;
    private Rigidbody2D rigid;
    protected RaycastHit2D slopeHit;
    protected const float RAY_DISTANCE = 4f;

    Vector2 direction = new Vector2();

    // Vector2 movement = new Vector2();
    [SerializeField] private float xInput;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        FreezePosition();
    }

    private void FixedUpdate()
    {
        rigid.velocity = AdjustDirectionToSlope() * 4;
    }

    public bool IsOnSlope() // 경사면에 있는지 체크
    {
        slopeHit = Physics2D.Raycast(rigid.position, Vector2.down, RAY_DISTANCE, LayerMask.GetMask("Ground"));
        if (slopeHit.collider != null)
        {
            var angle = Vector2.Angle(Vector2.up, slopeHit.normal);
            return angle != 0f && angle < maxSlopeAngle;
        }
        return false;
    }

    private Vector2 AdjustDirectionToSlope() // 이동 벡터와 경사면과의 각도를 가지고 진행 방향 벡터 구하기
    {
        slopeHit = Physics2D.Raycast(rigid.position, Vector2.down, RAY_DISTANCE, LayerMask.GetMask("Ground"));
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
            rigid.constraints = RigidbodyConstraints2D.FreezePositionX|RigidbodyConstraints2D.FreezeRotation;
        }
        else
        {
            rigid.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
}
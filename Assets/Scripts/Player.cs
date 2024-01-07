using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigid;

    public float speed;
    public float jumpForce;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");

        rigid.velocity = new Vector2(x, rigid.velocity.y / speed) * speed;
    }
}

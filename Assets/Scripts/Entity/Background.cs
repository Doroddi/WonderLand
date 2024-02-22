using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Background : MonoBehaviour
{
    private Transform transform;

    private float xInput;

    [SerializeField]
    private float MAX_X;
    [SerializeField] 
    private float MIN_X;

    [SerializeField]
    private float speed;

    private float positionY;

    [SerializeField]
    private bool withPlayer;

    private void Start()
    {
        transform = GetComponent<Transform>();
        positionY = transform.position.y;
    }

    private void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");

        if (!withPlayer)
        {
            transform.position = new Vector2(transform.position.x - xInput * speed, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - xInput * speed, positionY);
        }
    }
}

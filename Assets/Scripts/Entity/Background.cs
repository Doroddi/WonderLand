using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Background : MonoBehaviour
{
    private Transform transform;

    private float xInput;

    private void Start()
    {
        transform = GetComponent<Transform>();
    }

    private void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");

        transform.position = new Vector2(transform.position.x - xInput * 0.0001f, transform.position.y);
    }
}

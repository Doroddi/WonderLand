using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Wire : MonoBehaviour
{
    public SpriteRenderer wireMid;
    public GameObject lightOn;

    [SerializeField]
    // private Camera camera;

    Vector3 startPoint;
    Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        // Wire 하나
        startPoint = this.transform.parent.position;
        startPoint.z = 0;
        Debug.Log("startPoint: " + startPoint);
        // Moving 오브젝트
        startPosition = this.transform.position;
        Debug.Log("startPosition: " + startPosition);
    }

    // Update is called once per frame
    private void OnMouseDrag()
    {
        // mouse position to world point
        // Vector3 newPosition = camera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0;
        //Debug.Log(newPosition);

        // check for nearby connection Points
        Collider2D[] colliders = Physics2D.OverlapCircleAll(newPosition, .2f);
        foreach (Collider2D collider in colliders)
        {
            // make sure not my own collider
            if (collider.gameObject != gameObject)
            {
                // update wire to the connection point position
                UpdateWire(collider.transform.position);

                // check if the wires are same color
                if (transform.parent.name.Equals(collider.transform.parent.name))
                {
                    // count connection
                    Main.Instance.SwitchChange(1);

                    // finish step
                    collider.GetComponent<Wire>()?.Done();
                    Done();
                }
                return;
            }
        }
        // update wire
        UpdateWire(newPosition);
    }

    void Done()
    {
        // turn on light
        lightOn.SetActive(true);
    
        // destory the script
        Destroy(this);
    }

    private void OnMouseUp()
    {
        // Moving 오브젝트 위치로 재배치
        UpdateWire(startPosition);
    }

    void UpdateWire(Vector3 newPosition)
    {

        // update position
        transform.position = newPosition;
        //Debug.Log("res: " + (newPosition - startPoint));

        // update direction
        Vector3 direction = newPosition - startPoint;
        transform.right = direction * transform.lossyScale.x;

        // update scale 
        // -> 
        float dist = Vector2.Distance(startPoint, newPosition);
        wireMid.size = new Vector2(dist, wireMid.size.y);
        Debug.Log("size: " + wireMid.size);
    }
}

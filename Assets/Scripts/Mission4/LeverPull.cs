using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LeverPull : MonoBehaviour 
{
    public GameObject _handle;
    public GameObject lightOn;
    Vector3 startPoint;
    Vector3 startPosition;

    const float MAXY = 0.5f;
    const float MINY = -1.0f;

    float timelinePosY;
    public bool isInLine;

    void Start()
    {
        startPoint = transform.position;
        startPosition = transform.position;
        Debug.Log("x: " + startPoint.x);
        Debug.Log("y: " + startPoint.y);
    }


    public void OnMouseDrag()
    {
        // mouse position to world point
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Debug.Log(Input.mousePosition);
        newPosition.x = 0;
        newPosition.z = 0;

        
        // check for nearby connection Points
        Collider2D[] colliders = Physics2D.OverlapCircleAll(newPosition, .2f);
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject != gameObject)
            {
                // update
                UpdateWire(collider.transform.position);
                lightOn.SetActive(true);
                
                Destroy(this);
                return;
            }
        }

        UpdateWire(newPosition);

        // if(newPosition.y < MINY) newPosition.y = MINY;
        // if(newPosition.y > MAXY) newPosition.y = MAXY;
        // // update wire
        // // _handle.transform.position = newPosition;
        // transform.position = newPosition;
        // Debug.Log("handle y: " + _handle.transform.position.y);
        // //Vector3 direction = newPosition - startPoint;
        // //transform.right = direction;
    }
    
    public void OnMouseUp()
    {
        UpdateWire(startPosition);
    }
  
    void UpdateWire(Vector3 newPosition)
    {
        if(newPosition.y < MINY) newPosition.y = MINY;
        if(newPosition.y > MAXY) newPosition.y = MAXY;

        transform.position = newPosition;
    }

    // private void OnMouseUp()
    // {
    //     // reset wire position
    //     UpdateWire(startPosition);
    // }

    // void UpdateWire(Vector3 newPosition)
    // {
    //     // update position
    //     transform.position = newPosition;

    //     // update direction
    //     Vector3 direction = newPosition - startPoint;
    //     transform.right = direction;
    // }
}

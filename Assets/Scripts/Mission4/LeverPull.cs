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

    float MAXY;
    float MINY;

    float timelinePosY;
    public bool isInLine;   
    //[SerializeField]
    //private Camera camera;


    void Start()
    {
        startPoint = transform.position;
        startPosition = transform.position;
        Debug.Log("x: " + startPoint.x);
        Debug.Log("y: " + startPoint.y);
        MINY = startPosition.y - 1.0f;
        MAXY = startPosition.y;
    }


    public void OnMouseDrag()
    {
        // mouse position to world point
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Vector3 newPosition = camera.ScreenToWorldPoint(Input.mousePosition);
        newPosition.x = startPosition.x;
        // Debug.Log(Input.mousePosition);
        newPosition.z = 0;

        
        // check for nearby connection Points
        Collider2D[] colliders = Physics2D.OverlapCircleAll(newPosition, 0.1f);
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject != gameObject)
            {
                // update
                UpdateWire(collider.transform.position);
                lightOn.SetActive(true);
                //WaterTankSceneManager.instance.ExitMiniGame();
                Destroy(this);
                return;
            }
        }

        UpdateWire(newPosition);
    }
    
    public void OnMouseUp()
    {
        UpdateWire(startPosition);
    }
  
    void UpdateWire(Vector3 newPosition)
    {
        if(newPosition.y < MINY) {
            newPosition.y = MINY;
        }
        if(newPosition.y > MAXY) {
            newPosition.y = MAXY;
        }
        transform.position = newPosition;
    }
}

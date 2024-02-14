using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFloor : MonoBehaviour
{
   #region Elavate Machine info
    [SerializeField]
    private float movingDistance;

    private float startX;
    private float startY;
    private float targetX;
    [SerializeField]
    private float targetY;

    [SerializeField]
    private float machineMovingSpeed;

    [SerializeField]
    private bool isElevating;

    [SerializeField]
    private int moveDirection;
    
    [SerializeField]
    private bool isLoop;

    [SerializeField]
    private bool isVertical;
    #endregion

    // Start is called before the first frame update

    void Start()
    {
        startX = transform.position.x;
        startY = transform.position.y;
        targetX = startX;
        targetY = startY;
        StartMachine();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        // if e pressed down StartMachine
        if (isElevating)
        {
            MoveMachine();
        }
    }

    // change movement values of Machine when start
    public void StartMachine()
    {
        isElevating = true;
        if(isVertical) {
            targetY += (moveDirection * movingDistance);
        } else {
            targetX += (moveDirection * movingDistance);
        }
    }



    // move machine per tick checking whether the position is valid
    private void MoveMachine()
    {
        if(isVertical) {
            if (CheckMovedDistance(transform.position.y, targetY, moveDirection == 1))
        {
            moveDirection *= -1;
            targetY += (moveDirection * movingDistance);

            return;
        }
        transform.position = new Vector3(transform.position.x,
        transform.position.y + (moveDirection * machineMovingSpeed), 0);
        }
        else {
        if (CheckMovedDistance(transform.position.x, targetX, moveDirection == 1))
        {
            moveDirection *= -1;
            targetX += (moveDirection * movingDistance);

            return;
        }
        transform.position = new Vector3(transform.position.x + (moveDirection * machineMovingSpeed),
        transform.position.y  , 0);
        }
    }

    // TODO: FIXED POINT CALCULATION ISSUE
    private bool CheckMovedDistance(float curPoint, float objPoint, bool flag)
    {
        if (flag)
        {
            return objPoint - curPoint <= 0.001f;
        }
        return objPoint - curPoint >= 0.001f;
    }
}

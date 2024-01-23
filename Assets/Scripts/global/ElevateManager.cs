using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevateManager : NPC
{

    #region Elavate Machine info
    [SerializeField]
    private float movingDistance;

    private float startX;
    private float startY;
    private float targetX;
    private float targetY;

    [SerializeField]
    private float machineMovingSpeed;

    [SerializeField]
    private bool isElevating;

    private int moveDirection;

    #endregion

    // Start is called before the first frame update

    protected override void Start()
    {
        base.Start();
        moveDirection = 1;
        startX = transform.position.x;
        startY = transform.position.y;
        targetX = startX;
        targetY = startY;
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (!isElevating && Input.GetKeyDown(KeyCode.E) && interactionAvailable)
        {
            interaction.Invoke();
        }
    }

    protected override void FixedUpdate()
    {
        checkInteraction();
        // if e pressed down StartMachine
        if (isElevating)
        {
            MoveMachine();
        }
    }

    // Define separate checkInteraction Function.
    private void checkInteraction()
    {
        // get all components 
        Collider2D[] colliders = Physics2D.OverlapCircleAll(interactionCheck.position, interactionCheckRadius);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].GetComponent<Player>() != null)
            {
                interactionAvailable = true;
                return;
            }
        }
        interactionAvailable = false;
    }


    // change movement values of Machine when start
    public void StartMachine()
    {
        isElevating = true;
        targetY += (moveDirection * movingDistance);
    }

    private void EndMachine()
    {
        isElevating = false;
        moveDirection *= -1;
        return;
    }

    // move machine per tick checking whether the position is valid
    private void MoveMachine()
    {
        if (CheckMovedDistance(transform.position.y, targetY, moveDirection == 1))
        {
            EndMachine();
            return;
        }
        transform.position = new Vector3(transform.position.x,
        transform.position.y + (moveDirection * machineMovingSpeed), 0);
    }

    // TODO: FIXED POINT CALCULATION ISSUE
    private bool CheckMovedDistance(float curPoint, float objPoint, bool flag)
    {
        if (flag)
        {
            return objPoint - curPoint <= 0;
        }
        return objPoint - curPoint >= 0;
    }

    // This Function is for development. Only shows in Scene Mode.
    private void OnDrawGizmos()
    {
        // range based checking. using circular range
        Gizmos.DrawWireSphere(interactionCheck.position, interactionCheckRadius);

    }
}

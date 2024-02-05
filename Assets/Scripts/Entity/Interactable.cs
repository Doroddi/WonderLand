using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{

    #region interact objects

    [SerializeField]
    private DialogEvent[] dialogSystems;

    [SerializeField]
    private GameEvent[] gameEventSystems;

    #endregion

    [SerializeField] private Transform interactionCheck;
    [SerializeField] private float interactionCheckRadius;

    [SerializeField]
    private int nextInteractionOrder = 0;

    [SerializeField]
    private DialogTest dialogTest;

    [SerializeField]
    private bool isDialogLeft = true;

    [SerializeField]
    private bool interactionAvailable = false;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && interactionAvailable == true)
        {
            //check manager.
            InteractionElem nextElem = InteractionManager.instance.GetInteractionElem();

            if (!nextElem.isDialog)
            {

                return;
            }

            // interaction matched
            if(isDialogLeft && nextElem.order == dialogSystems[nextInteractionOrder].order)
            {

                dialogTest.AdaptDialogSystem(dialogSystems[nextInteractionOrder].dialogSystem);
                dialogTest.StartAsync(true);

                // if normal dialog pass
                if (!dialogSystems[nextInteractionOrder].isQuest)
                {
                    nextInteractionOrder++;
                }

                isDialogLeft = nextInteractionOrder < dialogSystems.Length;
            } else if (nextElem.order < nextInteractionOrder && isDialogLeft && dialogSystems[nextInteractionOrder].isQuest)
            {
                dialogTest.AdaptDialogSystem(dialogSystems[nextInteractionOrder].dialogSystem);
                dialogTest.StartAsync(false);
            }


/*

            if (isDialogLeft && nextElem.order == dialogSystems[nextInteractionOrder].order)
            {
                dialogTest.AdaptDialogSystem(dialogSystems[nextInteractionOrder].dialogSystem);
                dialogTest.StartAsync(true);
                if (!dialogSystems[nextInteractionOrder].isQuest)
                {
                    nextInteractionOrder++;
                }
                else
                {
                    InteractionManager.instance.ReQuest();
                }
                isDialogLeft = nextInteractionOrder < dialogSystems.Length;
            }
            else if (isDialogLeft && dialogSystems[nextInteractionOrder].isQuest)
            {
                dialogTest.AdaptDialogSystem(dialogSystems[nextInteractionOrder].dialogSystem);
                dialogTest.StartAsync(false);
            }*/
        }
    }

    private void FixedUpdate()
    {
        checkInteraction();
    }

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
}

[System.Serializable]
public struct DialogEvent
{
    public int order;
    public bool isQuest;
    public DialogSystem dialogSystem;

}

[System.Serializable]
public struct GameEvent
{
    public int order;

}

public struct GameEventSystem
{

}
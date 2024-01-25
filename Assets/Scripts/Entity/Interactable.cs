using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    #region interact objects

    [SerializeField]
    private DialogEvent[] dialogSystems;

    [SerializeField]
    private GameEvent[] gameEventSystems;

    #endregion

    [SerializeField]
    private int nextInteractionOrder = 0;

    [SerializeField]
    private DialogTest dialogTest;

    [SerializeField]
    private bool isDialogLeft = true;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //check manager.
            InteractionElem nextElem = InteractionManager.instance.GetInteractionElem();

            if (!nextElem.isDialog)
            {

                return;
            }
            if (isDialogLeft && nextElem.order == dialogSystems[nextInteractionOrder].order)
            {
                dialogTest.AdaptDialogSystem(dialogSystems[nextInteractionOrder].dialogSystem);
                dialogTest.StartAsync(true);
                nextInteractionOrder++;
                isDialogLeft = nextInteractionOrder < dialogSystems.Length;
            }
            else if (isDialogLeft && dialogSystems[nextInteractionOrder - 1].isQuest)
            {
                dialogTest.StartAsync(false);
            }


        }
    }



}

[System.Serializable]
public struct DialogEvent
{
    public int order;
    public bool isQuest;
    public DialogSystem dialogSystem;
}
public struct GameEvent
{
    int order;

    GameEventSystem gameEventSystem;
}
public struct GameEventSystem
{

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using UnityEditor.Events;

public class NPC : BaseEntity
{
    private NPCSentence nPCSentence;
    private bool chatBoxAvailable;

    [SerializeField] protected bool interactionAvailable;

    private int interaction_order;

    /*[System.Serializable]
    public class InteractionFunction : UnityEvent { };

    public InteractionFunction interaction;*/

    [SerializeField] UnityEvent dialog = null;

    public DialogTest dialogTest;

    public void Dialog()
    {
        dialog.AddListener(() => dialogTest.StartAsync());
        // UnityEventTools.AddPersistentListener(dialog, DialogTest.getInstance().StartAsync);
    }


    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
        nPCSentence = GetComponent<NPCSentence>();
        chatBoxAvailable = true;
        interaction_order = 0;
        Dialog();
    }

    protected override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.E)
            && interactionAvailable)
        {
            Debug.Log("E");
            dialog.Invoke();
            
            // EpisodeManager.Episode.index++;
        }
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

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
                if (chatBoxAvailable)
                {
                    nPCSentence.TalkNpc();
                    chatBoxAvailable = false;
                    StartCoroutine("DebounceChatBox");
                }
                interactionAvailable = true;
                return;
            }
        }
        interactionAvailable = false;
    }

    private IEnumerator DebounceChatBox()
    {
        yield return new WaitForSeconds(7f);
        chatBoxAvailable = true;
    }
}

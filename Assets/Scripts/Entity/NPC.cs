using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : BaseEntity
{
    private NPCSentence nPCSentence;
    private bool chatBoxAvailable;
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
        nPCSentence = GetComponent<NPCSentence>();
        chatBoxAvailable = true;
    }

    protected override void Update()
    {
        base.Update();
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

        foreach (var receiver in colliders)
        {
            if (chatBoxAvailable && receiver.GetComponent<Player>() != null)
            {
                nPCSentence.TalkNpc();
                chatBoxAvailable = false;
                StartCoroutine("DebounceChatBox");
            }
        }
    }

    private IEnumerator DebounceChatBox() {
        yield return new WaitForSeconds(7f);
        chatBoxAvailable = true;
    }
}

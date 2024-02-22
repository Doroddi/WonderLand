using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSentence : MonoBehaviour
{

    public string[] sentences;

    [SerializeField] private Transform chatTr;
    [SerializeField] private GameObject chatBoxPrefab;
    bool chatBoxAvailable = true;
    private void Start()
    {
        
    }

    void OnTriggerEnter2D (Collider2D coll) {
        if(chatBoxAvailable) {
            TalkNpc();
            StartCoroutine("DebounceChatBox");
        }
        chatBoxAvailable = false;
    }

     private IEnumerator DebounceChatBox()
    {
        yield return new WaitForSeconds(7f);
        chatBoxAvailable = true;
    }
    public void TalkNpc()
    {
        GameObject go = Instantiate(chatBoxPrefab);
        go.GetComponent<ChatSystem>().gameObject.SetActive(false);
        go.GetComponent<ChatSystem>().gameObject.transform.SetParent(transform);
        go.GetComponent<ChatSystem>().OnDialogue(sentences, chatTr);

    }

}

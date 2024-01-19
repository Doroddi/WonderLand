using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSentence : MonoBehaviour
{

    public string[] sentences;

    [SerializeField] private Transform chatTr;
    [SerializeField] private GameObject chatBoxPrefab;

    private void Start()
    {

    }

    public void TalkNpc()
    {
        GameObject go = Instantiate(chatBoxPrefab);
        go.GetComponent<ChatSystem>().gameObject.SetActive(false);
        go.GetComponent<ChatSystem>().gameObject.transform.SetParent(transform);

    
        go.GetComponent<ChatSystem>().OnDialogue(sentences, chatTr);

    }

}

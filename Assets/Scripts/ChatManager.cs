using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatManager : MonoBehaviour
{
    public static ChatManager chatManager;

    GameObject quadPrefab;

    Queue<ChatSystem> chatPool = new Queue<ChatSystem>();

    private void Awake() {
        chatManager = this;
        Debug.Log("init");
        InitChatPool(3);
    }
    private void InitChatPool(int cnt) {
        for(int i = 0; i < cnt; i++) {
            chatPool.Enqueue(CreateQuad());
        }
    }

    private ChatSystem CreateQuad() {
        var obj = Instantiate(quadPrefab).GetComponent<ChatSystem>();
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(transform);

        return obj;
    }


    public static ChatSystem NpcTalk(GameObject npc) {
        var quad = chatManager.chatPool.Dequeue();

        quad.gameObject.SetActive(true);
        quad.transform.SetParent(npc.transform);
        return quad;
    }

    public static void NpcTalkEnd(ChatSystem quad) {

        quad.gameObject.SetActive(false);
        quad.transform.SetParent(chatManager.transform);
        chatManager.chatPool.Enqueue(quad);
    }
    // Start is called before the first frame update

}

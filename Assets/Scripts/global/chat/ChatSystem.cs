using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChatSystem : MonoBehaviour
{

    public Queue<string> sentences;
    public string currentSentence;
    public GameObject quad;

    public TextMeshPro textObj;


  

    public void OnDialogue(string[] lines, Transform chatPoint)
    {
        transform.position = chatPoint.position;
        sentences = new Queue<string>();
        sentences.Clear();

        foreach (var line in lines)
        {
            sentences.Enqueue(line);

        }
        gameObject.SetActive(true);
        StartCoroutine(DialogueFlow(chatPoint));
    }

    IEnumerator DialogueFlow(Transform chatPoint)
    {
        yield return null;
        while (sentences.Count > 0)
        {
            currentSentence = sentences.Dequeue();
            textObj.text = currentSentence;
            float x = textObj.preferredWidth;
            x = (x>3) ? 3: x + 1f;
            quad.SetActive(true);
            quad.transform.localScale = new Vector2(x, textObj.preferredHeight);

            transform.position = new Vector2(chatPoint.position.x, chatPoint.position.y + textObj.preferredHeight / 2);
            yield return new WaitForSeconds(3f);
        }
        Destroy(gameObject);
    }
}

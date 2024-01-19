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


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

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
            x = (x>3) ? 3: x + 0.3f;
            quad.SetActive(true);
            quad.transform.localScale = new Vector2(x, textObj.preferredHeight + 0.3f);
            transform.position = new Vector2(chatPoint.position.x, chatPoint.position.y + textObj.preferredHeight / 2);
            yield return new WaitForSeconds(3f);
        }
        Destroy(gameObject);
    }
}

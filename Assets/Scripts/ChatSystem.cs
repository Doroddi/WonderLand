using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChatSystem : MonoBehaviour
{

    public Queue<string> sentences;
    public string currentSentence;

    public TextMeshPro textObj;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnDialogue(string[] lines)
    {
        sentences = new Queue<string>();
        sentences.Clear();

        foreach (var line in lines)
        {
            sentences.Enqueue(line);

        }
        StartCoroutine(DialogueFlow());
    }

    IEnumerator DialogueFlow()
    {
        yield return null;
        while (sentences.Count > 0)
        {
            currentSentence = sentences.Dequeue();
            textObj.text = currentSentence;
            yield return new WaitForSeconds(3f);
        }
        Destroy(gameObject);
    }
}

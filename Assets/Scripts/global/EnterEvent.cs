using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class EnterEvent : ElevateManager
{
    [SerializeField]
    private bool isEntered = false;

    [SerializeField]
    private SpriteRenderer sprite;
    public GameObject go;

    /*private float timer;
    private float waitingTime;
*/
 /*   protected override void Start()
    {
        timer = 0f;
        waitingTime = 2f;
    }
*/
    protected override void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && interactionAvailable)
        {
            if (!isEntered)
            {
                anim.SetTrigger("FadeOut");
                isEntered = true;
                go.SetActive(true);
                anim.SetTrigger("FadeIn");
            }
            else
            {
                anim.SetTrigger("FadeOut");
                isEntered = false;
                go.SetActive(false);
                anim.SetTrigger("FadeIn");
            }
        }
    }

}
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
                StartCoroutine("Enter");
            }
            else
            {
                StartCoroutine("Exit");
            }
        }
    }

    private IEnumerator Enter()
    {
        GameManager.instance.Stop();

        anim.SetTrigger("FadeOut");
        isEntered = true; 

        yield return new WaitForSeconds(1);

        go.SetActive(true);

        yield return new WaitForSeconds(1);

        anim.SetTrigger("FadeIn");

        GameManager.instance.Resume();
    }

    private IEnumerator Exit()
    {
        GameManager.instance.Stop();

        anim.SetTrigger("FadeOut");
        isEntered = false;

        yield return new WaitForSeconds(1);

        go.SetActive(false);


        yield return new WaitForSeconds(1);

        anim.SetTrigger("FadeIn");

        GameManager.instance.Resume();
    }
}
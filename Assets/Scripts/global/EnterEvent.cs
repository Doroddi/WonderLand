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

    protected override void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && interactionAvailable)
        {
            if (!isEntered)
            {
                //ImageFadeIn();
                anim.SetTrigger("FadeOut");
                isEntered = true;
            }
            else
            {
                //ImageFadeOut();
                anim.SetTrigger("FadeIn");
                isEntered = false;
            }
        }
    }

    /*private void ImageFadeIn()
    {
        sprite.color.a =
        while(color.a <= 255f)
        {
            color.a -= 1;
            sprite.color = color;
        }
    }

    private void ImageFadeOut()
    {
        Color color = sprite.color;
        while (color.a >= 0f)
        {
            color.a -= 1;
            sprite.color = color;
        }
    }*/
}
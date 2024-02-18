using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextScene : MonoBehaviour
{

    public string nextSceneName;

    [SerializeField]
    private bool autoTransMode = true;

    [SerializeField]
    private bool isNextEpisode;

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (isNextEpisode)
        {
            GameManager.instance.DestroyInteractionManager();
        }
        if (autoTransMode)
        {
            GameManager.instance.NextScene();

        }
        else
        {
            Debug.Assert(nextSceneName != null);
            GameManager.instance.NextScene(nextSceneName);
        }
    }

}

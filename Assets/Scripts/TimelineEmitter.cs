using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class TimelineEmitter : MonoBehaviour
{


    [SerializeField]
    private PlayableDirector playableDirector;

    private bool isRepeatable = false;

    private bool isPlayable = true;

    public void Play()
    {
        if (isPlayable)
        {
            playableDirector.Play();
            isPlayable = isRepeatable;
        }
    }


}

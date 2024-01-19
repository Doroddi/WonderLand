using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EpisodeManager : MonoBehaviour
{
    public static EpisodeManager Episode;

    public int index;

    private void Awake()
    {
        if (Episode == null)
            Episode = this;
        else if(Episode != this)
        {
            Destroy(gameObject);
        }
    }
}

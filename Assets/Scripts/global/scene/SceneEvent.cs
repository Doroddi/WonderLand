using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneEvent : MonoBehaviour
{
    public static SceneEvent Scene;

    [SerializeField]
    FadeOIEvent fadeOI;

    private void Awake()
    {
        if (Scene == null)
            Scene = this;
        else if (Scene != this)
        {
            Destroy(gameObject);
        }
    }

}
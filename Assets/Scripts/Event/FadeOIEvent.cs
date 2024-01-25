using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeOIEvent : MonoBehaviour
{
    [SerializeField] private Animator trasitionAnim;


    private void SyncFadeOIEvent()
    {
        trasitionAnim.SetTrigger("FadeOut");
        trasitionAnim.SetTrigger("FadeIn");
    }
}

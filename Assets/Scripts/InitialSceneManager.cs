using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialSceneManager : MonoBehaviour
{
    public SceneTransitionManager sceneTrasitionManager;
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextScene : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D coll)
    {
        GameManager.instance.NextScene();
    }
}

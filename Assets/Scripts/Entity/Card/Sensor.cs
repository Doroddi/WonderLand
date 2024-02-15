using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    public bool isRead = false;
    void Start()
    {
        Debug.Log("awake");
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("hi");
        if (!other.gameObject.CompareTag("Card")) return;
        isRead = true;
    }
    void OnTriggerExit2D(Collider2D other)
    {

    }

    public void Reload()
    {
        isRead = false;
    }

    public void Check()
    {
        isRead = true;
    }
}

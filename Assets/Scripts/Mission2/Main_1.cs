using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_1 : MonoBehaviour
{
    static public Main_1 Instance;

    public int switchCount;
    public GameObject winText;
    private int onCount = 0;

    private void Awake() 
    {
        Instance = this;
    }
    public void SwitchChange(int points)
    {
        onCount = onCount + points;
        if (onCount == switchCount)
        {
            winText.SetActive(true);
        }
    }
}

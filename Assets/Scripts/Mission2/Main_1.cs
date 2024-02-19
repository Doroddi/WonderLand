using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_1 : MonoBehaviour
{
    static public Main_1 Instance;

    public int switchCount;
    private int onCount = 0;
    public GameObject yellowGameObject;
    private Vector3 initPosition;

    private void Awake() 
    {
        Instance = this;
        initPosition = yellowGameObject.transform.position;
    }
    public void SwitchChange(int points)
    {
        onCount = onCount + points;

        yellowGameObject.transform.localScale = new Vector3(onCount * 0.4f, 0.2f, 0f);

        yellowGameObject.transform.position = new Vector3(initPosition.x + 0.5f * yellowGameObject.transform.localScale.x, 0.45f, 0f);

        if (onCount == switchCount)
        {
            WaterTankSceneManager.instance.ExitMiniGame();
        }
    }
}

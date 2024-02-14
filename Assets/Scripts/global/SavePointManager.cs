using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePointManager : MonoBehaviour
{
    // Start is called before the first frame update

    private static SavePointManager _instance;

    public static SavePointManager Instance()
    {
        return _instance;
    }

    void Awake()
    {
        _instance = this;
    }

    [SerializeField]
    private Transform[] savePoints;

    [SerializeField]
    private int curPoint;

    [SerializeField]
    private GameObject _player;

    private bool isSaveEnabled;

    void Start()
    {
        isSaveEnabled = true;
        _player.GetComponent<Player>().airState.onFallingHigh += ResetPosition;
    }

    private void ResetPosition(SavePointManager manager)
    {
        if (!isActiveAndEnabled) return;

        _player.transform.position = savePoints[curPoint].position;
    }

    private void UpdateSavePoint(int nextPoint)
    {
        if (nextPoint >= savePoints.Length)
        {
            isSaveEnabled = false;
        }
        curPoint = nextPoint;
    }


}

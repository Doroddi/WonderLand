using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private Slider slider;

    [SerializeField]
    private bool onceTimeCheck;

    public void onClickNewGame()
    {
        if (!onceTimeCheck)
        {
            GameManager.instance.NextScene();
            onceTimeCheck = true;
        }
    }

    public void onClickExit()
    {
        Application.Quit();
    }

    private void Update()
    {
        GameManager.instance.sound = slider.value;
    }
}
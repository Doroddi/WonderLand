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

    public void onClickNewGame()
    {
        GameManager.instance.NextScene();
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
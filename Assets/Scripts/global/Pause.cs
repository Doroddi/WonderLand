using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public static Pause instance;

    [SerializeField]
    private Slider slider;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        slider.value = GameManager.instance.sound;
    }

    private void Update()
    {
        GameManager.instance.sound = slider.value;
    }

    public void onClickPause()
    {
        gameObject.SetActive(true);
    }
    
    public void onClickResume()
    {
        gameObject.SetActive(false);
    }

    public void onClickExit()
    {
        Application.Quit();
    }
}

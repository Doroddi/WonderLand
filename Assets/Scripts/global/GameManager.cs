using System.Collections;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private SceneTransitionManager sceneTransitionManager;

    public bool isResume = true;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    private void Update()
    {

    }

    public void NextScene()
    {
        sceneTransitionManager.NextLevel();
    }

    public void Resume()
    {
        isResume = true;
    }

    public void Stop()
    {
        isResume = false;
    }
}
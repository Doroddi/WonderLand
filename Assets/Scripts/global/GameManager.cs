using System.Collections;
using System.Net;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private SceneTransitionManager sceneTransitionManager;

    [SerializeField]
    public CinemachineVirtualCamera _cineMachineVirtualCamera;

    [SerializeField]
    public InteractionManager interactionManager;

    [SerializeField]
    public float sound;

    public bool isResume = true;

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
    }

    public void NextScene()
    {
        sceneTransitionManager.NextLevel();
    }

    public void NextScene(string sceneName)
    {
        sceneTransitionManager.ToTargetLevel(sceneName);
    }

    public void Resume()
    {
        isResume = true;
    }

    public void Stop()
    {
        isResume = false;
    }

    public void FixCinemachineVertically()
    {
        _cineMachineVirtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_YDamping = 0;
    }

    public void ReleaseCinemacineVertically()
    {
        _cineMachineVirtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_YDamping = 1;
    }

    public void DestroyInteractionManager()
    {
        Destroy(InteractionManager.instance.gameObject);
    }
}
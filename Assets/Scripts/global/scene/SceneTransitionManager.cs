using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using static UnityEditor.Experimental.GraphView.Port;
using UnityEngine.UIElements.Experimental;
using Cinemachine;

public class SceneTransitionManager : MonoBehaviour
{
    [SerializeField] private Animator trasitionAnim;

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        GameManager.instance._cineMachineVirtualCamera = GameObject.FindWithTag("PC").GetComponent<CinemachineVirtualCamera>();
    }

    public void NextLevel()
    {
        StartCoroutine(FadeOINextScene());
    }

    public void ToTargetLevel(string sceneName)
    {
        StartCoroutine(FadeOITargetScene(sceneName));
    }

    IEnumerator FadeOINextScene()
    {
        trasitionAnim.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        trasitionAnim.SetTrigger("FadeIn");
    }

    IEnumerator FadeOITargetScene(string sceneName)
    {
        trasitionAnim.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1);
        // assertion needed
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        trasitionAnim.SetTrigger("FadeIn");
    }
}
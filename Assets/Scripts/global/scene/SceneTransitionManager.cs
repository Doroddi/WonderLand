using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using static UnityEditor.Experimental.GraphView.Port;
using UnityEngine.UIElements.Experimental;

public class SceneTransitionManager : MonoBehaviour
{
    [SerializeField] private Animator trasitionAnim;

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
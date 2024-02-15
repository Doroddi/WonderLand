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
        StartCoroutine(FadeOI());
    }

    IEnumerator FadeOI()
    {
        trasitionAnim.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1);
        // SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("WaterTank", LoadSceneMode.Single);
        trasitionAnim.SetTrigger("FadeIn");
    }
}
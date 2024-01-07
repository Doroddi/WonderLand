using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using static UnityEditor.Experimental.GraphView.Port;

public class SceneTransitionManager : MonoBehaviour
{
    [SerializeField] Animator trasitionAnim;

    public void NextLevel()
    {
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {
        trasitionAnim.SetTrigger("out");
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        trasitionAnim.SetTrigger("in");
    }
}
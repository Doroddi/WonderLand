using UnityEngine;
using UnityEngine.UI;
using System.Threading;
 
public class SceneTransitionManager : MonoBehaviour
{
 
	public Image fadeImage;
    public float fadeSpeed = 0.5f;
    private bool fadeDir = true;
    private void Awake(){
        fadeImage = GetComponent<Image>();
        Thread.Sleep(2000);
    }

    private void Update()
    {
        Color color = fadeImage.color;
        if(fadeDir){
            color.a += Time.deltaTime*fadeSpeed;
            if(color.a>1) fadeDir =false;
        }
        else {
            color.a -= Time.deltaTime*fadeSpeed;
            if(color.a<0) fadeDir=true;
        }

        fadeImage.color = color;

	}
 
}
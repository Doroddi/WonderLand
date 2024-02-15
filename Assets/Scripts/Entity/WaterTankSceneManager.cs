using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTankSceneManager : MonoBehaviour
{

    public static WaterTankSceneManager instance;



    [SerializeField]
    private MiniGame[] minigameLauncher;

    [SerializeField]
    Camera mainCamera;
    Camera curCamera;

    
    
    void Awake() {
        instance = this;
        Camera.main.enabled = true;
        foreach (MiniGame _mg in minigameLauncher) {
            _mg.camera.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void SetupMiniGame(int gameIdx) {
        // 1. stop player
        GameManager.instance.Stop();
        // 2. shift Camera
        SwitchCamera(Camera.main, minigameLauncher[gameIdx].camera);
    }

    public void ExitMiniGame() {
        GameManager.instance.Resume();
        SwitchCamera(curCamera, mainCamera);
    }

    void SwitchCamera (Camera prev, Camera next) {
        Debug.Log(next);

        if(prev != null && next != null) { 
            prev.enabled = false;
            next.enabled = true;
            curCamera = next;
        }
    }
}

[System.Serializable]
public struct MiniGame {

    public MiniGame (GameObject go, Camera cm) {
        this.go = go;
        this.camera = cm;
    }

    public GameObject go;
    public Camera camera;

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLink : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private bool isGameStart;

    [SerializeField]
    private Vector2 interactableRange;

    private Camera _camera;

    [SerializeField]
    private int gameOrder;  
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /**if(!isGameStart) {  
            RaycastHit2D hit = Physics2D.BoxCast(transform.position, interactableRange , 0, Vector2.up, 0f,LayerMask.GetMask("Player"));
            if(hit.collider != null && Input.GetKeyDown(KeyCode.E)) {
                isGameStart = true;
                WaterTankSceneManager.instance.SetupMiniGame(gameOrder);
            }   
        }**/
    }

   public void StartGame() {
        if(!isGameStart) {  
            isGameStart = true;
            WaterTankSceneManager.instance.SetupMiniGame(gameOrder);
        }
    }

}

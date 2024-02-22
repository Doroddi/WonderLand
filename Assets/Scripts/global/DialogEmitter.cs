using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogEmitter : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] 
    private DialogTest dialogManager;
    [SerializeField] 
    private DialogSystem dialogSystem;
    bool isEmitted = false;

    void OnTriggerEnter2D(Collider2D coll) {
        if(!isEmitted &&(coll.gameObject.layer == LayerMask.NameToLayer("Player"))) {
            dialogManager.AdaptDialogSystem(dialogSystem);
            isEmitted = true;
            dialogManager.StartAsync(true);
        }   
    }
}

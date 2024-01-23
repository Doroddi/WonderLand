using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalSystem : MonoBehaviour
{

    [SerializeField]
    private GameObject currentPortal;

    private void Update() {
        if(Input.GetKeyDown(KeyCode.E)) {
            if(currentPortal != null) {
                transform.position = currentPortal.GetComponent<Portal>().GetDestination().position;
            }
        }
    }
    

    //TODO: portal transition cross scenes.
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.layer.Equals(LayerMask.NameToLayer("Portal"))) {
            currentPortal = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.gameObject.layer.Equals(LayerMask.NameToLayer("Portal"))) {
            if(collision.gameObject == currentPortal) {
                currentPortal = null;
            }
        }
    }
}

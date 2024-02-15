using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanishGround : MonoBehaviour
{

    [SerializeField]
    private Vector2 boxCast;
    [SerializeField]
    private Vector2 pos;

    private bool isCoroutineStart = false;
    // Start is called before the first frame update
    void Start()
    {
        boxCast = new Vector2(0.4f, 0.1f);
        pos = new Vector2(transform.position.x, transform.position.y - 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void FixedUpdate() {
        if(!isCoroutineStart) {
            RaycastHit2D hit = Physics2D.BoxCast(pos, boxCast , 0, Vector2.up, 0f,LayerMask.GetMask("Player"));
            if(hit.collider != null && hit.collider.gameObject.GetComponent<Player>().isJump) {
                isCoroutineStart = true;
                StartCoroutine("VanishBlock");   
            }
        }
    }


    IEnumerator VanishBlock () {
        yield return new WaitForSeconds(1.5f);
        Invoke("RecoverBlock", 3.0f);
        gameObject.SetActive(false);
    }
    
    void RecoverBlock () {
        gameObject.SetActive(true);
        isCoroutineStart = false;
    }
    private void OnDrawGizmos() {
        Vector2 pos = new Vector2(transform.position.x, transform.position.y - 0.5f);
        Gizmos.DrawCube(pos, new Vector3(0.4f,0.1f,0));
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public GameObject _card;

    Vector3 startPosition;
    RectTransform CurrentPos;
    Transform onDragParent;
    [SerializeField]
    CardReader cardReader;

    public Transform startParent;
    public void Start()
    {
        CurrentPos = gameObject.GetComponent<RectTransform>();
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        _card = gameObject;

        startPosition = transform.position;
        // startParent = transform.parent;

        // GetComponent<CanvasGroup>().blocksRaycasts = false;
        // transform.SetParent(onDragParent);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 mousePoint = Input.mousePosition;
        Debug.Log(mousePoint);
        Vector3 pos = new Vector3(Math.Min(mousePoint.x, 500f), mousePoint.y, 0f);
        transform.position = pos;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 10f, LayerMask.GetMask("Sensor"));
        if (hit) hit.collider.GetComponent<Sensor>().Check();

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = startPosition;
        Debug.Log(cardReader.Verify());
        if (cardReader.Verify())
        {
            Debug.Log("Success!");
        }

        cardReader.RebootSensors();
    }

}

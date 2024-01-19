using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Interaction : MonoBehaviour
{
    // ���ͷ��� ���� ����
    [SerializeField] private bool enableInteraction;
    [SerializeField] private int index;

    [System.Serializable]
    public class InteractionFunction : UnityEvent { };

    public InteractionFunction interaction;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && enableInteraction == true && index == EpisodeManager.Episode.index)
        {
            interaction.Invoke();
            EpisodeManager.Episode.index++;
        }
    }

    // "Player" ���̾ ������ ���ͷ��� ���� ���θ� true�� ����
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer.Equals(LayerMask.NameToLayer("Player")))
        {
            enableInteraction = true;
        }
    }

    // "Player" ���̾ ����� ���ͷ��� ���� ���θ� false�� ����
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer.Equals(LayerMask.NameToLayer("Player")))
        {
            enableInteraction = false;
        }
    }
}
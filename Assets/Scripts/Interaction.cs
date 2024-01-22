using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Interaction : MonoBehaviour
{
    [SerializeField] private bool enableInteraction;
    [SerializeField] private int index;

    [System.Serializable]
    public class InteractionFunction : UnityEvent { };

    public InteractionFunction interaction;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && enableInteraction && index == EpisodeManager.Episode.index)
        {
            interaction.Invoke();
            EpisodeManager.Episode.index++;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer.Equals(LayerMask.NameToLayer("Player")))
        {
            enableInteraction = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer.Equals(LayerMask.NameToLayer("Player")))
        {
            enableInteraction = false;
        }
    }
}
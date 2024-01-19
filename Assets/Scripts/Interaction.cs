using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Interaction : MonoBehaviour
{
    // 인터랙션 가능 여부
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

    // "Player" 레이어를 만나면 인터랙션 가능 여부를 true로 저장
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer.Equals(LayerMask.NameToLayer("Player")))
        {
            enableInteraction = true;
        }
    }

    // "Player" 레이어를 벗어나면 인터랙션 가능 여부를 false로 저장
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer.Equals(LayerMask.NameToLayer("Player")))
        {
            enableInteraction = false;
        }
    }
}
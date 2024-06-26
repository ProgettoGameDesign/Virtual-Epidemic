using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateofConversation : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        if (DialogueManager.Instance.isDialogueActive)
        {
            gameObject.layer = 0;

        }
        if (!DialogueManager.Instance.isDialogueActive)
        Invoke("NPCBackInteractable", 0.5f);
    }
    private void NPCBackInteractable()
    {
        gameObject.layer = 7;
    }
}

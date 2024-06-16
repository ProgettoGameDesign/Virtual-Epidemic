using System.Collections;
using System.Collections.Generic;
using DialogueEditor;
using UnityEngine;

public class StartConversation : MonoBehaviour
{
    [SerializeField] TPM_characterController playerController;
    [SerializeField] NPCConversation _npcconversation;
    private void OnTriggerEnter(Collider other)
    {
        StartDialogue();
    }
    void StartDialogue()
    {
        playerController._canmove = false;
        playerController._inputSpeed = 0;
        ConversationManager.Instance.StartConversation(_npcconversation);
    }

void OnDialogueEnd()
    {
        playerController._canmove = true;
    }

}

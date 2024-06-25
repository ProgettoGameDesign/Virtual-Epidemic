using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralNPCconversation : MonoBehaviour, InteractInterface
{
    [SerializeField] private Dialogue dialogue;
    [SerializeField] private string _prompt;
    [SerializeField] SceneState sceneState;
    public string InteractionPrompt => _prompt;
    public bool Interact(Interactor interactor)
    {
        if (DialogueManager.Instance.isDialogueActive == false)
        {
            Debug.Log("non è attivo");
            sceneState.blockMovementPlayer = true;
            DialogueManager.Instance.StartDialogue(dialogue);
        }
        /*
        else
        {
            Debug.Log("è attivo");
            DialogueManager.Instance.DisplayNextDialogueLine();
        }*/
        return true;
    }
}

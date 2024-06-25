using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VerraInteract : MonoBehaviour, InteractInterface
{
    [SerializeField] private SceneState playerData;
    [SerializeField] private string _prompt;
    [SerializeField] private GameObject transition;
    [SerializeField] Animator _animatorNerraSveglio;
    [SerializeField] private Dialogue dialogue;

    public string InteractionPrompt => _prompt;
    public bool Interact(Interactor interactor)
    {
        transition.SetActive(true);
        playerData.blockMovementPlayer = true;
        Invoke("LoadNewNerra", 2);
        Invoke("AnimazioneRisveglio",2.3f);
        Invoke("StartDialogue",5);
        return true;
    }
    private void LoadNewNerra() 
    {
        playerData.NerraCutscene = true;
        
    }
    private void StartDialogue()
    {
        DialogueManager.Instance.StartDialogue(dialogue);
    }
    private void AnimazioneRisveglio() 
    {
        _animatorNerraSveglio.SetBool("trigger", true);

    }
}

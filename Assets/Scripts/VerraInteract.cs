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
        Invoke("LoadNewNerra", 1);
        Invoke("StartDialogue",3);
        return true;
    }
    private void LoadNewNerra() 
    {
        playerData.NerraCutscene = true;
        _animatorNerraSveglio.SetBool("trigger", true);
        
    }
    private void StartDialogue()
    {
        DialogueManager.Instance.StartDialogue(dialogue);
    }
    
}

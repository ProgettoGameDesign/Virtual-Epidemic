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
    [SerializeField] private FadeToWhite fadeToWhite;
    [SerializeField] private Dialogue dialogue;
    

    public string InteractionPrompt => _prompt;
    public bool Interact(Interactor interactor)
    {
        playerData.blockMovementPlayer = true;
        StartCoroutine(fadeToWhite.FadeToWhiteTransition());
        // Disattiva tutti i volumi di post-processing dopo ColorTransition
        if (PostProcessingManager.Instance != null)
        {
            Debug.Log("Disattiva i volumi di post-processing");
            PostProcessingManager.Instance.DisableAllVolumes();
        }
        else
        {
            Debug.LogError("PostProcessingManager instance is null.");
        }
        Invoke("ColorTransition",1);
        Invoke("LoadNewNerra", 2);
        Invoke("AnimazioneRisveglio",2.3f);
        Invoke("StartDialogue",5);
        return true;
    }
    private void ColorTransition()    
    {
        transition.SetActive(true);
    }
    private void LoadNewNerra() 
    {
        playerData.NerraCutscene = true;
        
    }
    private void StartDialogue()
    {
        DialogueManager.Instance.StartDialogue(dialogue);
        transition.SetActive(false);
    }
    private void AnimazioneRisveglio() 
    {
        _animatorNerraSveglio.SetBool("trigger", true);

    }
}

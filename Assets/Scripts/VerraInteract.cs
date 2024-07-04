using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VerraInteract : MonoBehaviour, InteractInterface
{
    [SerializeField] private SceneState playerData;
    [SerializeField] private string _prompt;
    [SerializeField] private GameObject transition;
    [SerializeField] Animator _animatorNerraSveglio;
    [SerializeField] private FadeToWhite fadeToWhite;
    [SerializeField] private GameObject canvasWhiteTransition;
    [SerializeField] private GameObject _torch;
    [SerializeField] private Dialogue dialogue;
    


    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        _torch.SetActive(false);
        playerData.blockMovementPlayer = true;
        canvasWhiteTransition.SetActive(true);
        StartCoroutine(HandleCutsceneSequence());
        return true;
    }

    private IEnumerator HandleCutsceneSequence()
    {
        yield return StartCoroutine(fadeToWhite.FadeToWhiteTransition());

        // Ritarda la transizione del colore di 1 secondo
        Invoke("ColorTransition", 0.5f);

        // Disattiva i volumi di post-processing dopo la transizione del colore con un ritardo di 1 secondo
        yield return new WaitForSeconds(0.5f);
        if (PostProcessingManager.Instance != null)
        {
            Debug.Log("Disattiva i volumi di post-processing");
            PostProcessingManager.Instance.DisableAllVolumes();
        }
        else
        {
            Debug.LogError("PostProcessingManager instance is null.");
        }

        yield return new WaitForSeconds(3);
        //Invoke("FadeOut",0.5f);
        
        
        // Ritarda il caricamento della nuova scena
        yield return new WaitForSeconds(0.5f);
        Invoke("LoadNewNerra", 0.5f);
        Invoke("AnimazioneRisveglio", 0.8f);    
        Invoke("StartDialogue", 2);

        

        yield return null;
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

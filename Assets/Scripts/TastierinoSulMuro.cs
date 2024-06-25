using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TastierinoSulMuro : MonoBehaviour, InteractInterface
{
    [SerializeField] private SceneState playerData;
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;
    [SerializeField] GameObject _tastierinotoappear;
    [SerializeField] Animator animator;
    public bool Interact(Interactor interactor)
    {
        if (playerData.blockMovementPlayer == false)    
        {
            playerData.blockMovementPlayer = true;
            _tastierinotoappear.SetActive(!_tastierinotoappear.activeSelf);
            animator.Play("show");
        }
        else 
        {
            playerData.blockMovementPlayer = false;
            _tastierinotoappear.SetActive(!_tastierinotoappear.activeSelf);
            //animator.Play("hide");
        }
        return true;
    }
    
}

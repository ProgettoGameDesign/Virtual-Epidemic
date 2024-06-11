using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contatore : MonoBehaviour, InteractInterface
{
    [SerializeField] private string _prompt;
    [SerializeField] public SceneState sceneState;
    [SerializeField] Animator _animator;
    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        if (sceneState._hasKey == true)
        {
            Debug.Log("Sportello aperto!");
            _animator.SetBool("key", true);
        }
            
        else Debug.Log("Trova chiave per aprire lo sportello");
        return true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour, InteractInterface
{
    [SerializeField] private SceneState playerData;
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;
    public bool Interact(Interactor interactor)
    {
        playerData._hasKey = true;
        gameObject.SetActive(false); 
        return true;
        
    }
}

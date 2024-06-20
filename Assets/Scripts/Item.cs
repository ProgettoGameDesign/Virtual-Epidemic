using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Item : MonoBehaviour, InteractInterface
{
    [SerializeField] private SceneState playerData;
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;
    public bool Interact(Interactor interactor)
    {
        Debug.Log("Hai preso l'oggetto!");
        
        if(_prompt == "Torch")               
        {
            playerData._torchActive = true;
        }
        gameObject.SetActive(false); 
        return true;
        
    }
}

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
        //gameObject.SetActive(false);
        /*
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
            if (meshRenderer != null)
            {
                meshRenderer.enabled = false;}*/
        if(_prompt == "Torch")               
        {
            playerData._torchActive = true;
        }
        gameObject.SetActive(false); 
        return true;
        
    }
}

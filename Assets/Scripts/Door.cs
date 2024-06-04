using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour, InteractInterface
{
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        if (_prompt == "Door-M") { SceneManager.LoadScene("Corridoio_M");}
        else
        Debug.Log("Hai aperto la porta!");        
        return true;
    }
}

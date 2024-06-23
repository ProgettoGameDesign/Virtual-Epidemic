using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TastierinoSulMuro : MonoBehaviour, InteractInterface
{
    //[SerializeField] private SceneState playerData;
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;
    [SerializeField] GameObject _tastierinotoappear;
    public bool Interact(Interactor interactor)
    {
        _tastierinotoappear.SetActive(!_tastierinotoappear.activeSelf);
        return true;
    }
    
}

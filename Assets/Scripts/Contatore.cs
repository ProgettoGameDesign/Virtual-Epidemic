using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contatore : MonoBehaviour, InteractInterface
{
    [SerializeField] private string _prompt;
    [SerializeField] public SceneState sceneState;
    [SerializeField] Animator _animator;
    [SerializeField] CameraSwitchTarget cameraSwitchTarget;
    [SerializeField] GameObject _lightTransition;
    [SerializeField] GameObject _light1;
    [SerializeField] GameObject _light2;

    public string InteractionPrompt => _prompt;


    public bool Interact(Interactor interactor)
    {
        if (_animator.GetBool("key") == false)
        {
            if (sceneState._hasKey == true)
        {
            Debug.Log("Sportello aperto!");
            _animator.SetBool("key", true);
        } 
            else Debug.Log("Trova chiave per aprire lo sportello");
        }
        else
        {
            Debug.Log("Hai acceso la luce!");
            _lightTransition.SetActive(true);
            Invoke("ActiveLight", 4);
            Invoke("SwitchTarget",5);

        }
        return true;
    }
    private void ActiveLight()
    {
        _light1.SetActive(true);
        _light2.SetActive(true);
    }
    private void SwitchTarget()
    {
        cameraSwitchTarget.SwitchToNPCTarget();
    }
}

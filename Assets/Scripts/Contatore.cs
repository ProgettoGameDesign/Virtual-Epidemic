using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contatore : MonoBehaviour, InteractInterface
{
    [SerializeField] private string _prompt;
    [SerializeField] public SceneState sceneState;
    [SerializeField] private Animator _animator;
    [SerializeField] private CameraSwitchTarget cameraSwitchTarget;
    [SerializeField] private GameObject _lightTransition;
    [SerializeField] private Animator _NPCanimator;
    [SerializeField] private GameObject _NPC;

    public string InteractionPrompt => _prompt;
    void Awake()
    {
        if(sceneState._lightup == true)
        {
            _animator.SetBool("key", true);
            Destroy(_NPC);
        }
    }

    public bool Interact(Interactor interactor)
    {
        if (!_animator.GetBool("key"))
        {
            _animator.SetBool("key", true);
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
        sceneState._lightup = true;
    }
    private void SwitchTarget()
    {
        cameraSwitchTarget.SwitchToNPCTarget();
        _NPCanimator.SetBool("trigger", true);
    }
}

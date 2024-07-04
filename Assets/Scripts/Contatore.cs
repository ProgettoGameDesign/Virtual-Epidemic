using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Contatore : MonoBehaviour, InteractInterface
{
    [SerializeField] private string _prompt;
    [SerializeField] public SceneState sceneState;
    [SerializeField] private Animator _animator;
    [SerializeField] private CameraSwitchTarget cameraSwitchTarget;
    [SerializeField] private GameObject _lightTransition;
    [SerializeField] private Animator _NPCanimator;
    [SerializeField] private Button textcanvas;
    [SerializeField] private GameObject canvasContatore;
    //[SerializeField] private GameObject _NPC;

    public string InteractionPrompt => _prompt;
    

    public bool Interact(Interactor interactor)
    {
        if (!_animator.GetBool("key"))
        {
            _animator.SetBool("key", true);
            gameObject.GetComponent<CanvasActive>().enabled = false;
            //canvasContatore.SetActive(false);
            textcanvas.GetComponentInChildren<TextMeshProUGUI>().text = "(E) Accendi";
        }
        else
        {
            canvasContatore.SetActive(false);
            gameObject.layer = 0;
            gameObject.GetComponent<Outline>().enabled = false;
            gameObject.GetComponent<LightContatore>().enabled = false;
            Debug.Log("Hai acceso la luce!");
            sceneState.blockMovementPlayer = true;
            _lightTransition.SetActive(true);
            _lightTransition.GetComponent<Animator>().SetBool("trigger",true);
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

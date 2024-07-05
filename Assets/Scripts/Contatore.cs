using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using FMODUnity;
using FMOD.Studio;
using FMOD;
using System.Linq;

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
    public EventInstance eventInstance;
    public string eventpath = "";

    public string InteractionPrompt => _prompt;
    private StudioEventEmitter mainCameraEmitter;
   
    private float targetVolume = -24.0f;  // Volume di destinazione (ad esempio abbassare a 20%)
    

       void Start()
    {
        // Ottieni il riferimento al FMOD Event Emitter sulla Main Camera
        mainCameraEmitter = Camera.main.GetComponent<StudioEventEmitter>();

    }
    
    public bool Interact(Interactor interactor)
    {
        if (!_animator.GetBool("key"))
        {
            _animator.SetBool("key", true);
            gameObject.GetComponent<CanvasActive>().enabled = false;
            //canvasContatore.SetActive(false);
            SoundCoperchio();
            textcanvas.GetComponentInChildren<TextMeshProUGUI>().text = "(E) Accendi";
        }
        else
        {
            canvasContatore.SetActive(false);
            gameObject.layer = 0;
            gameObject.GetComponent<Outline>().enabled = false;
            gameObject.GetComponent<LightContatore>().enabled = false;
            UnityEngine.Debug.Log("Hai acceso la luce!");
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
        LightSound();
        AdjustVolume();
      

    }
    private void SwitchTarget()
    {
        cameraSwitchTarget.SwitchToNPCTarget();
        _NPCanimator.SetBool("trigger", true);
    }

    private void LightSound()
    {
       
       eventInstance = RuntimeManager.CreateInstance(eventpath);
       eventInstance.setParameterByName("Tipo", 0);
       eventInstance.start();
       eventInstance.release();

    }
    private void SoundCoperchio()
    {
        eventInstance = RuntimeManager.CreateInstance(eventpath);
        eventInstance.setParameterByName("Tipo", 1);
        eventInstance.start();
        eventInstance.release();

    }

    private void AdjustVolume()
    {
        mainCameraEmitter.SetParameter("Volume", targetVolume);
        mainCameraEmitter.SetParameter("VolumeRamp", 1 );
        
    }
  
}

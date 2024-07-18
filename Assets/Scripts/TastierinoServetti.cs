using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using FMOD;

public class TastierinoServetti : MonoBehaviour
{
    public string correctSequence = "BRGYCM";
    private string currentSequence = "";
    private float timeToWait = 0.3f;
    private Outline _outlineTastierino;
    [SerializeField] SceneState sceneState;
    [SerializeField] Animator animator;
    [SerializeField] GameObject display1;
    [SerializeField] GameObject display2;
    [SerializeField] GameObject display3;
    [SerializeField] GameObject display4;
    [SerializeField] GameObject display5;
    [SerializeField] GameObject display6;
    [SerializeField] GameObject tastierinoSulMuro;
    [SerializeField] GameObject canvasDaDistruggere;
    private EventInstance eventInstance;
    private string fmodEventPath1 = "event:/UI/Feedback_tasti";
    private StudioEventEmitter mainCameraEmitter;
    

    // Start is called before the first frame update
    public void AddDigit(string digit)
    {
        currentSequence += digit;
        //displayText.text = currentSequence;
        CheckSequence();
    }
    private void CheckSequence()
    {
        if (currentSequence.Length == correctSequence.Length)
        {
            Invoke("ResetDisplay", timeToWait+1);
            if (currentSequence == correctSequence)
            {
                Destroy(canvasDaDistruggere);
                _outlineTastierino.OutlineColor = Color.green;
                _outlineTastierino.enabled = true;
                SoundCorrect();
                //_outlineDisplay.OutlineColor = Color.green;
                //_outlineDisplay.enabled = true;
                sceneState.blockMovementPlayer = false;
                animator.Play("hide");
                StartCoroutine(SequenzaGiusta());
                tastierinoSulMuro.layer = 0;
                UnityEngine.Debug.Log("Sequenza corretta! La porta si apre.");
                //currentSequence = "";
                
                sceneState.tastierinoServetti = true;
                Invoke("StopMusic", 2.5f);

                
            }
            else
            {
                _outlineTastierino.OutlineColor = Color.red;
                _outlineTastierino.enabled = true;
                //_outlineDisplay.OutlineColor = Color.red;
                //_outlineDisplay.enabled = true;
                SoundFalse();
                StartCoroutine(SequenzaSbagliata());
                UnityEngine.Debug.Log("Sequenza sbagliata! Ripristino.");
                // Resetta la sequenza
                
                //displayText.text = currentSequence;
            }
        }
    }
    private IEnumerator SequenzaGiusta()
    {
        yield return new WaitForSeconds(timeToWait+1);
        gameObject.SetActive(false);
        
        
        //sceneState.tastierino = true;


    }
    private IEnumerator SequenzaSbagliata()
    {
        yield return new WaitForSeconds(timeToWait);
        _outlineTastierino.enabled = false;
        //_outlineDisplay.enabled = false;
        currentSequence = "";
        //asterisco1.SetActive(false);
        //asterisco2.SetActive(false);
        //asterisco3.SetActive(false);
        //asterisco4.SetActive(false);

    }
    void Start()
    {
        _outlineTastierino = gameObject.GetComponent<Outline>();
        _outlineTastierino.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        UnityEngine.Debug.Log(currentSequence);
        UnityEngine.Debug.Log(correctSequence);
        
    }
    public void IlluminaDisplay(string colore)
    {
        if (currentSequence.Length == 1)
        display1.GetComponent<ChangeColorDisplay>().ChangeColor(colore);
        else if (currentSequence.Length == 2)
        display2.GetComponent<ChangeColorDisplay>().ChangeColor(colore);
        else if (currentSequence.Length == 3)
        display3.GetComponent<ChangeColorDisplay>().ChangeColor(colore);
        else if (currentSequence.Length == 4)
        display4.GetComponent<ChangeColorDisplay>().ChangeColor(colore);
        else if (currentSequence.Length == 5)
        display5.GetComponent<ChangeColorDisplay>().ChangeColor(colore);
        else if (currentSequence.Length == 6)
        display6.GetComponent<ChangeColorDisplay>().ChangeColor(colore);

        SoundButton();

    }
    private void ResetDisplay()
    {
        display1.GetComponent<Renderer>().material.color = Color.white;
        display2.GetComponent<Renderer>().material.color = Color.white;
        display3.GetComponent<Renderer>().material.color = Color.white;
        display4.GetComponent<Renderer>().material.color = Color.white;
        display5.GetComponent<Renderer>().material.color = Color.white;
        display6.GetComponent<Renderer>().material.color = Color.white;
    }
    private void StopMusic()
    {
        mainCameraEmitter = Camera.main.GetComponent<StudioEventEmitter>();
        mainCameraEmitter.Stop();

    }

    private void SoundCorrect()
    {
        eventInstance = RuntimeManager.CreateInstance(fmodEventPath1);
        eventInstance.setParameterByName("FeedbackTasti", 1);
        eventInstance.start();
        eventInstance.release();
    }

    private void SoundFalse()
    {
        eventInstance = RuntimeManager.CreateInstance(fmodEventPath1);
        eventInstance.setParameterByName("FeedbackTasti", 2);
        eventInstance.start();
        eventInstance.release();  
    }

     private void SoundButton(){
        eventInstance = RuntimeManager.CreateInstance(fmodEventPath1);
        eventInstance.setParameterByName("FeedbackTasti", 0);
        eventInstance.start();
        eventInstance.release();
    }
}

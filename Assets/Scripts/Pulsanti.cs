using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using UnityEngine;
using FMODUnity;

public class Pulsanti : MonoBehaviour
{
    public string buttonValue;
    [SerializeField] private ManagerTastierino keypadManager;
    [SerializeField] private Animator animator;

    private EventInstance eventInstance;
    private string eventFmodPath = "event:/UI/Feedback_tasti";


    void OnMouseDown()
    {
        if (keypadManager != null)
        {
            //Debug.Log("hai premuto 1");
            keypadManager.AddDigit(buttonValue);
            animator.SetBool("premuto", true);
            SoundButton();

        }
    }

    private void SoundButton(){
        eventInstance = RuntimeManager.CreateInstance(eventFmodPath);
        eventInstance.setParameterByName("FeedbackTasti", 0);
        eventInstance.start();
        eventInstance.release();
    }
    
}

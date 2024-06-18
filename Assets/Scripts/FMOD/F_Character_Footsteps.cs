using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class F_Character_Footsteps : MonoBehaviour
{
    // Start is called before the first frame update
    private int MaterialValue;
    private RayCastHit rh;
    private float distance = 0.3f;
    private string EventPath = "event:/footsteps_character";
    private PARAMETER_ID ParamID;
    private PARAMETER_ID ParamID2;
    private LayerMask lm;

    private EventDescription EventDes;
    private PARAMETER_DESCRIPTION ParamDes;


    void Start()
    {
        lm = LayerMask.GetMask("Ground");
    }

    void PlayRunEvent()
    {
        MaterialCheck();
        EventInstance Run = RuntimeManager.CreateInstance(EventPath);
        RuntimeManager.AttachInstanceToGameObject(Run, transform, GetComponent<RigidBody>());


        Run.setParameterByID(ParamID2, 1, false);

        Run.start();
        Run.release();

    }

    void PlayWalkEvent()
    {
        MaterialCheck();
        EventInstance Walk = RuntimeManager.CreateInstance(EventPath);
        RuntimeManager.AttachInstanceToGameObject(Walk, transform, GetComponent<RigidBody>());

        Walk.setParameterByID(ParamID, MaterialValue, false);


    }



    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCutsceneNerra : MonoBehaviour
{
    [SerializeField] GameObject NerraScemo;
    [SerializeField] GameObject NerraSveglio;
    
    //[SerializeField] Animator _animatorNerraSveglio;
    [SerializeField] SceneState sceneState;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (sceneState.NerraCutscene == true)    
        {
            NerraScemo.SetActive(false);
            NerraSveglio.SetActive(true);
            //_animatorNerraSveglio.SetBool("trigger", true);
        }
    }
}

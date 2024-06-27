using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateAula3 : MonoBehaviour
{
    [SerializeField] SceneState sceneState;
    [SerializeField] GameObject NPC;
    [SerializeField] GameObject Contatore; 

    
    void Awake()
    {
        if(sceneState._lightup == true)
        {
            Contatore.GetComponent<Animator>().SetBool("key", true);
            Contatore.GetComponent<Outline>().enabled = false;
            Contatore.GetComponent<LightObject>().enabled = false;
            gameObject.GetComponent<CanvasActive>().enabled = false;
            Contatore.layer = 0;
            Destroy(NPC);
        }

        
    }

    
}
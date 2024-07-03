using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateAula3 : MonoBehaviour
{
    [SerializeField] SceneState sceneState;
    [SerializeField] GameObject NPC;
    [SerializeField] GameObject Contatore; 
    [SerializeField] GameObject canvaContatore;

    
    void Start()
    {
        if(sceneState._lightup == true)
        {
            Destroy(NPC);
            Contatore.layer = 0;
            AggiornaContatore();
            
        }

        
    }
    private void AggiornaContatore()
    {
        Destroy(canvaContatore);
        Contatore.GetComponent<Animator>().SetBool("key", true);
        Contatore.GetComponent<Outline>().enabled = false;
        Contatore.GetComponent<LightObject>().enabled = false;
        //gameObject.GetComponent<CanvasActive>().enabled = false;
        
            

    }
}

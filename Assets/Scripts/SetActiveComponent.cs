using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActive : MonoBehaviour
{
    [SerializeField] SceneState sceneState;

    // Update is called once per frame
    void Update()
    {
        if(sceneState.tastierino == true)  
        {
            gameObject.layer = 7;
            gameObject.GetComponent<LightDoor>().enabled = true;
            //gameObject.GetComponent<Outline>().enabled = true;
        }
    }
}

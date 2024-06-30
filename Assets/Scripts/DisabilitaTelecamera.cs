using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisabilitaTelecamera : MonoBehaviour
{
    [SerializeField] GameObject telecameraScena;
    [SerializeField] SceneState sceneState;

    // Update is called once per frame
    void Update()
    {
        if(sceneState._torchActive == true)
        {
            telecameraScena.SetActive(false);

        }
    }
}

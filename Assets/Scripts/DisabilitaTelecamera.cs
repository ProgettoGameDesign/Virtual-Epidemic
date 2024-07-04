using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisabilitaTelecamera : MonoBehaviour
{
    [SerializeField] GameObject telecameraScena;
    //[SerializeField] GameObject _torciaCamera;
    [SerializeField] SceneState sceneState;

    // Update is called once per frame
    void Update()
    {
        if(sceneState._torchActive == true)
        {
            telecameraScena.SetActive(false);
            //_torciaCamera.SetActive(true);

        }
        /*
        if(sceneState._torchActive == false)
        {
            _torciaCamera.SetActive(false);

        }*/
    }
}

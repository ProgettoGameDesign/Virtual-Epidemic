using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class LightTrigger : MonoBehaviour
{
    private Light _light;
    void Start()
    {
        _light = gameObject.GetComponent<Light>();
        if (_light == null)
            {
                Debug.LogError("Nessun componente Light trovato su questo GameObject o assegnato.");
            }
        else _light.intensity = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        _light.intensity = 50;
        
    }

    private void OnTriggerExit(Collider other)
    {
        _light.intensity = 0;
        
    }
}

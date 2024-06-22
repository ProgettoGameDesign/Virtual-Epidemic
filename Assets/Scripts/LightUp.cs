using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightUp : MonoBehaviour
{
    [SerializeField] SceneState sceneState;
    private Light _light;
    void Start()
    {
        _light = gameObject.GetComponent<Light>();

    }
    
    void Update()
    {
        if(sceneState._lightup == true)
        _light.enabled = true;
        
    }
}

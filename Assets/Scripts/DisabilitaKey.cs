using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisabilitaKey : MonoBehaviour
{
    [SerializeField] SceneState sceneState;
    [SerializeField] GameObject key;
    // Update is called once per frame
    void Update()
    {
        if (sceneState._hasKey)    
        {
            key.SetActive(false);

        }
    }
}
